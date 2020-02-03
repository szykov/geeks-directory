using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Attributes;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;

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
        private readonly IProfilesService context;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public ProfilesController(IProfilesService context, IMapperService mapperService, ILogger<ProfilesController> logger)
        {
            this.context = context;
            this.mapper = mapperService.GetExceptionMapper();
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
        public ActionResult<GeekProfileResponsesKit> GetProfiles(
            int limit = 10,
            int offset = 0,
            string? orderBy = nameof(GeekProfile.ProfileId),
            string? orderDirection = "ASC")
        {
            var profiles = this.context.Get(limit, offset, orderBy, orderDirection);
            return this.Ok(profiles);
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
        public ActionResult<GeekProfileResponse> GetMyProfile()
        {
            var userName = this.User.Identity.Name!;
            var profile = this.context.Get(userName);

            return this.Ok(profile);
        }

        // GET: /api/profiles/search?query={query}
        /**
         * <summary>Search profiles</summary>
         * <remarks>Search for profiles based on query.</remarks>
         * <param name="query">Query for filtering profiles</param>
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
        public ActionResult<IEnumerable<GeekProfileResponse>> SearchProfiles(
            [RequiredFromQuery]string query,
            int limit = 10,
            int offset = 0,
            string? orderBy = nameof(GeekProfile.ProfileId),
            string? orderDirection = "ASC")
        {
            var profiles = this.context.Search(query, limit, offset, orderBy, orderDirection);
            return this.Ok(profiles);
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
        public ActionResult<GeekProfileResponse> GetProfile([FromRoute]int id)
        {
            var profile = this.context.Get(id);
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
            var profile = await this.context.AddAsync(model);
            return this.CreatedAtRoute(nameof(GetProfile), new { profile.Id }, profile);
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
        public ActionResult<GeekProfileResponse> UpdatePersonalProfile([FromBody]GeekProfileModel model)
        {
            var userName = this.User.Identity.Name!;

            var profile = this.context.Update(userName, model);
            return this.Ok(profile);
        }
    }
}
