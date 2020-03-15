using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Attributes;
using GeeksDirectory.Domain.Models;
using GeeksDirectory.Domain.Responses;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OpenIddict.Validation;

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
    public class ProfilesController : BaseApiController
    {
        private readonly IMediator mediator;
        private readonly ILogger logger;

        public ProfilesController(IMediator mediator, ILogger<ProfilesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        // GET: /api/profiles?limit={limit}&offset={offset}
        /**
         * <summary>Get profiles</summary>
         * <remarks>Get profiles.</remarks>
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
            int limit,
            int offset,
            string? orderDirection,
            string? orderBy = nameof(GeekProfile.Id))
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
            var user = await this.mediator.Send(new GetCurrentUserQuery());

            var query = new GetProfileByEmailQuery(user.Email);
            var profile = await this.mediator.Send(query);

            return this.Ok(profile);
        }

        // GET: /api/profiles/search?filter={filter}
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
        public async Task<ActionResult<GeekProfilesResponse>> SearchProfiles(
            [RequiredFromQuery]string filter,
            int limit,
            int offset,
            string? orderDirection,
            string? orderBy = nameof(GeekProfile.Id))
        {
            var query = new SearchProfilesQuery(filter, limit, offset, orderBy, orderDirection);
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
            var query = new GetProfileByIdQuery(id);
            var profile = await this.mediator.Send(query);

            return this.Ok(profile);
        }

        // POST: /api/profiles
        /**
         * <summary>Register profile</summary>
         * <remarks>Register new profile.</remarks>
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

            if (result.IsFailed)
                return this.UnprocessableEntity(result);

            var profile = new GetProfileByIdQuery(result.Value);
            return this.CreatedAtRoute(nameof(GetProfile), new { result.Value }, profile);
        }

        // PATCH: /api/profiles/me
        /**
         * <summary>Update profile</summary>
         * <remarks>Update user profile properties except email.</remarks>
         * <param name="model">User profile model</param>
         * <returns>Updated user profile</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpPatch("me")]
        public async Task<ActionResult<GeekProfileResponse>> UpdatePersonalProfile([FromBody]GeekProfileModel model)
        {
            var user = await this.mediator.Send(new GetCurrentUserQuery());

            var command = new UpdateProfileCommand(model, user.Profile.Id);
            var result = await this.mediator.Send(command);

            if (result.IsFailed)
                return this.UnprocessableEntity(result);

            var query = new GetProfileByIdQuery(result.Value);
            var profile = await this.mediator.Send(query);

            return this.Ok(profile);
        }
    }
}
