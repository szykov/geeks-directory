using AutoMapper;

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

        // GET: /api/profiles?take={take}&skip={skip}
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<GeekProfileResponse>> GetProfiles(int take = 25, int skip = 0)
        {
            try
            {
                var profiles = this.context.Get(take, skip);
                return this.Ok(profiles);
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
        public ActionResult<IEnumerable<GeekProfileResponse>> SearchProfiles([FromQuery]string query)
        {
            try
            {
                var profiles = this.context.Search(query);
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
        [HttpGet("{id}", Name = "GetProfile")]
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
        public async Task<ActionResult<GeekProfileResponse>> RegisterProfile([FromBody]GeekProfileModel model)
        {
            try
            {
                var profile = await this.context.AddAsync(model);
                return this.CreatedAtRoute(nameof(GetProfile), new { Id = profile.ProfileId }, profile);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to update profile.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // PATCH: /api/profiles/{id}
        [HttpPatch("{id}")]
        public ActionResult<GeekProfileResponse> UpdateProfile([FromRoute]int id, [FromBody]GeekProfileModel model)
        {
            try
            {
                this.context.Update(id, model);
                return this.NoContent();
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to update profile.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }
    }
}
