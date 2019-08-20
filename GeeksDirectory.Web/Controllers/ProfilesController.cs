using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;

namespace GeeksDirectory.Web.Controllers
{
    [Authorize]
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
            this.mapper = mapperService.GetExceptionResponseMapper();
            this.logger = logger;
        }

        // GET: /api/profiles
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<GeekProfile>> GetProfiles()
        {
            try
            {
                var profiles = this.context.Get();
                return this.Ok(profiles);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // GET: /api/profiles/{id}
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<GeekProfile> GetProfile([FromRoute]int id)
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

        // GET: /api/profiles?search={search}
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<GeekProfile>> SearchProfiles([FromQuery]string search)
        {
            try
            {
                var profiles = this.context.Search(search);
                return this.Ok(profiles);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to search in profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // POST: /api/profiles
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<GeekProfile> RegisterProfile([FromBody]ProfileModel model)
        {
            try
            {
                var profile = this.context.Add(model);
                return this.CreatedAtRoute(nameof(GetProfile), new { Id = profile.ProfileId }, profile);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to update profile.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // PATCH: /api/profiles/{id}
        [HttpPatch]
        public ActionResult<GeekProfile> UpdateProfile([FromRoute]int id, [FromBody]ProfileModel model)
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
