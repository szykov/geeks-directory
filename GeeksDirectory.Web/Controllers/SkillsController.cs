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

namespace GeeksDirectory.Web.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    [Route("api/profiles")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService context;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public SkillsController(ISkillsService context, IMapperService mapperService, ILogger<ProfilesController> logger)
        {
            this.context = context;
            this.mapper = mapperService.GetExceptionMapper();
            this.logger = logger;
        }

        // POST: /api/profiles/{profileId}/skills
        [HttpPost("{profileId}/skills")]
        public ActionResult<IEnumerable<GeekProfileResponse>> AddSkill([FromRoute]int profileId, [FromBody]SkillModel model)
        {
            try
            {
                this.context.Add(profileId, model);
                return this.NoContent();
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // POST: /api/profiles/{profileId}/skills/{skillName}
        [HttpPost("{profileId}/skills/{skillName}")]
        public ActionResult<IEnumerable<GeekProfileResponse>> SetScore([FromRoute]int profileId, [FromRoute]string skillName, [FromBody]int score)
        {
            try
            {
                this.context.SetScore(profileId, skillName, score);
                return this.NoContent();
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }
    }
}