using AutoMapper;

using GeeksDirectory.SharedTypes.Attributes;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OpenIddict.Validation;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<GeekProfileResponsesKit> GetProfiles(int limit, int offset, string? orderBy, string? orderDirection)
        {
            try
            {
                var profiles = this.context.Get(limit, offset, orderBy, orderDirection);
                return this.Ok(profiles);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // GET: /api/profiles/me
        [HttpGet("me")]
        public ActionResult<GeekProfileResponse> GetMyProfile()
        {
            try
            {
                var userName = this.User.Identity.Name!;
                var profile = this.context.Get(userName);

                return this.Ok(profile);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // GET: /api/profiles/search?query={query}
        [AllowAnonymous]
        [HttpGet("search")]
        public ActionResult<IEnumerable<GeekProfileResponse>> SearchProfiles([RequiredFromQuery]string query, int limit, int offset, string? orderBy, string? orderDirection)
        {
            try
            {
                var profiles = this.context.Search(query, limit, offset, orderBy, orderDirection);
                return this.Ok(profiles);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to search in profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // GET: /api/profiles/{id}
        [AllowAnonymous]
        [HttpGet("{id}", Name = nameof(GetProfile))]
        public ActionResult<GeekProfileResponse> GetProfile([FromRoute]int id)
        {
            try
            {
                var profile = this.context.Get(id);
                return this.Ok(profile);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to get profile.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // POST: /api/profiles
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<GeekProfileResponse>> RegisterProfileAsync([FromBody]CreateGeekProfileModel model)
        {
            try
            {
                var profile = await this.context.AddAsync(model);
                return this.CreatedAtRoute(nameof(GetProfile), new { profile.Id }, profile);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to update profile.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // PATCH: /api/profiles/me
        [HttpPatch("me")]
        public ActionResult<GeekProfileResponse> UpdatePersonalProfile([FromBody]GeekProfileModel model)
        {
            try
            {
                var userName = this.User.Identity.Name!;

                var profile = this.context.Update(userName, model);
                return this.Ok(profile);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to update profile.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }
    }
}
