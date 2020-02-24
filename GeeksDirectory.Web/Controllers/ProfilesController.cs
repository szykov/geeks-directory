using GeeksDirectory.Data.Entities;
using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.SharedTypes.Attributes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OpenIddict.Validation;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Controllers
{
    /**
     * <summary>Profiles controller with actions related to profiles</summary>
     * <remarks>CRUD operations regarding profiles.</remarks>
     **/
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProfilesController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger logger;

        public ProfilesController(IMediator mediator, ILogger<ProfilesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        // GET: /api/profiles?take={limit}&skip={offset}
        /**
         * <summary>Get profile</summary>
         * <remarks>Searches profiles in database.</remarks>
         * <param name="limit">Limit how many matches will be returned</param>
         * <param name="offset">How many matched users will be skipped</param>
         * <param name="orderBy">Order by which profile's property</param>
         * <param name="orderDirection">Either ASC or DESC</param>
         * <returns>Collecitons of profiles</returns>
        **/
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet]
        public async Task<ActionResult<GeekProfilesResponse>> GetProfiles(
            int limit = 10,
            int offset = 0,
            string? orderBy = nameof(GeekProfile.ProfileId),
            string? orderDirection = "asc")
        {
            var query = new GetProfilesQuery(limit, offset, orderBy, orderDirection);
            var profile = await this.mediator.Send(query);
            return this.Ok(profile);
        }

        // GET: /api/profiles/me
        /**
         * <summary>Get personal profile</summary>
         * <remarks>Get personal profile based on authenticated credentials.</remarks>
         * <returns>Profile of authentificated user</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("me")]
        public async Task<ActionResult<GeekProfileResponse>> GetMyProfile()
        {
            var query = new GetPersonalProfileQuery();
            var profile = await this.mediator.Send(query);
            return this.Ok(profile);
        }

        // GET: /api/profiles/search?query={query}
        /**
         * <summary>Search profiles</summary>
         * <remarks>Search for profiles based on query.</remarks>
         * <param name="filter">Text for filtering profiles</param>
         * <param name="limit">Limit how many matches will be returned</param>
         * <param name="offset">How many matched users will be skipped</param>
         * <param name="orderBy">Order by which profile's property</param>
         * <param name="orderDirection">Either ASC or DESC</param>
         * <returns>Profile of authentificated user</returns>
        **/
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GeekProfileResponse>>> SearchProfiles(
            [RequiredFromQuery]string filter,
            int limit = 10,
            int offset = 0,
            string? orderBy = nameof(GeekProfile.ProfileId),
            string? orderDirection = "asc")
        {
            var query = new SearchQuery(filter, limit, offset, orderBy, orderDirection);
            var profile = await this.mediator.Send(query);
            return this.Ok(profile);
        }

        // GET: /api/profiles/{id}
        /**
         * <summary>Get profile</summary>
         * <remarks>Get profile by id.</remarks>
         * <param name="id">User profile id</param>
         * <returns>User profile</returns>
        **/
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("{id}", Name = nameof(GetProfile))]
        public async Task<ActionResult<GeekProfileResponse>> GetProfile([FromRoute]int id)
        {
            var query = new GetProfileQuery(id);
            var profile = await this.mediator.Send(query);
            return this.Ok(profile);
        }

        // POST: /api/profiles
        /**
         * <summary>Register profile</summary>
         * <remarks>Add new profile to database.</remarks>
         * <param name="model">User profile model</param>
         * <returns>Created user profile</returns>
        **/
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<GeekProfileResponse>> RegisterProfileAsync([FromBody]CreateGeekProfileModel model)
        {
            var query = new RegisterProfileCommand(model);
            var result = await this.mediator.Send(query);

            var profile = new GetProfileQuery(result.Value);
            return this.CreatedAtRoute(nameof(GetProfile), new { result.Value }, profile);
        }

        // PATCH: /api/profiles/me
        /**
         * <summary>Update profile</summary>
         * <remarks>Update user profile in database.</remarks>
         * <param name="model">User profile model</param>
         * <returns>Updated user profile</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpPatch("me")]
        public async Task<ActionResult<GeekProfileResponse>> UpdatePersonalProfile([FromBody]GeekProfileModel model)
        {
            var query = new UpdatePersonalProfileCommand(model);
            var result = await this.mediator.Send(query);

            var profile = new GetProfileQuery(result.Value);
            return this.Ok(profile);
        }
    }
}
