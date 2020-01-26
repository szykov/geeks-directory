using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using OpenIddict.Abstractions;
using OpenIddict.Server;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationServer.Controllers
{
    /**
     * <summary>Authorization Controller for generating JWT Oauth2 tokens</summary>
     * <remarks>Methods related to authorization and authentication.</remarks>
    **/
    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Consumes("application/x-www-form-urlencoded")]
    [Produces("application/json")]
    public class AuthorizationController : Controller
    {
        private readonly IOptions<IdentityOptions> identityOptions;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthorizationController(IOptions<IdentityOptions> identityOptions, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.identityOptions = identityOptions;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        // POST: /connect/token
        /// <summary>Generate JWT token</summary>
        /// <remarks>Creates **Oauth2** token with **client credentials** flow scheme and **Bearer** token type.
        /// **grant_type** should be always specified as **client_credentials**.
        /// For **clientId** and **clientSecret** please send a request to the administrator. Send different request for each required scope.
        ///
        /// curl -X POST
        /// http://geeks-directory.azurewebsites.net/ \
        /// -H 'Content-Type: application/x-www-form-urlencoded' \
        /// -H 'cache-control: no-cache' \
        /// -d 'grant_type=client_credentials%26client_id=my-client%26client_secret=my-secret%26scope=manage_users_groups'
        /// </remarks>
        /// <example>
        /// grant_type:client_credentials&amp;client_id:my-client&amp;client_secret:my-secret&amp;scope:manage_users
        /// </example>
        /// <param name="request">Request with clientID, clientSecret, scope and etc</param>
        /// <returns>Returns JWT token</returns>
        [HttpPost("~/connect/token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<AuthTokenResponse>> Exchange(OpenIdConnectRequest request)
        {
            if (request.IsPasswordGrantType())
            {
                var user = await userManager.FindByNameAsync(request.Username);
                if (user == null)
                {
                    var invalidGrantError = new ErrorResponse(OpenIdConnectConstants.Errors.InvalidGrant, "The username/password couple is invalid.");
                    return BadRequest(invalidGrantError);
                }

                // Validate the username/password parameters and ensure the account is not locked out.
                var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
                if (!result.Succeeded)
                {
                    var invalidGrantError = new ErrorResponse(OpenIdConnectConstants.Errors.InvalidGrant, "The username/password couple is invalid.");
                    return BadRequest(invalidGrantError);
                }

                // Create a new authentication ticket.
                var ticket = await CreateTicketAsync(request, user);

                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }

            var unsupportedGrantTypeError = new ErrorResponse(OpenIdConnectConstants.Errors.UnsupportedGrantType, "The specified grant type is not supported.");
            return BadRequest(unsupportedGrantTypeError);
        }

        private async Task<AuthenticationTicket> CreateTicketAsync(OpenIdConnectRequest request, ApplicationUser user)
        {
            // Create a new ClaimsPrincipal containing the claims that
            // will be used to create an id_token, a token or a code.
            var principal = await signInManager.CreateUserPrincipalAsync(user);

            // Create a new authentication ticket holding the user identity.
            var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), OpenIddictServerDefaults.AuthenticationScheme);

            // Set the list of scopes granted to the client application.
            ticket.SetScopes(new[]
            {
                OpenIdConnectConstants.Scopes.OpenId,
                OpenIdConnectConstants.Scopes.Email,
                OpenIdConnectConstants.Scopes.Profile,
                OpenIddictConstants.Scopes.Roles
            }.Intersect(request.GetScopes()));

            ticket.SetResources("resource-server");

            // Note: by default, claims are NOT automatically included in the access and identity tokens.
            // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
            // whether they should be included in access tokens, in identity tokens or in both.

            foreach (var claim in ticket.Principal.Claims)
            {
                // Never include the security stamp in the access and identity tokens, as it's a secret value.
                if (claim.Type == identityOptions.Value.ClaimsIdentity.SecurityStampClaimType)
                {
                    continue;
                }

                var destinations = new List<string>
                {
                    OpenIdConnectConstants.Destinations.AccessToken
                };

                // Only add the iterated claim to the id_token if the corresponding scope was granted to the client application.
                // The other claims will only be added to the access_token, which is encrypted when using the default format.
                if ((claim.Type == OpenIdConnectConstants.Claims.Name && ticket.HasScope(OpenIdConnectConstants.Scopes.Profile)) ||
                    (claim.Type == OpenIdConnectConstants.Claims.Email && ticket.HasScope(OpenIdConnectConstants.Scopes.Email)) ||
                    (claim.Type == OpenIdConnectConstants.Claims.Role && ticket.HasScope(OpenIddictConstants.Claims.Roles)))
                {
                    destinations.Add(OpenIdConnectConstants.Destinations.IdentityToken);
                }

                claim.SetDestinations(destinations);
            }

            return ticket;
        }
    }
}