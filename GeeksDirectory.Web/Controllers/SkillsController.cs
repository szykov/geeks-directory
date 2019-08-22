using AutoMapper;

using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OpenIddict.Validation;

using System.ComponentModel.DataAnnotations;

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

        // GET: /api/profiles/{profileId}/skills/{skillName}
        [AllowAnonymous]
        [HttpGet("{profileId}/skills/{skillName}", Name = "GetSkill")]
        public ActionResult<SkillResponse> GetSkill([FromRoute]int profileId, [FromRoute]string skillName)
        {
            try
            {
                return this.context.Get(profileId, skillName);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // POST: /api/profiles/{profileId}/skills
        [HttpPost("{profileId}/skills")]
        public ActionResult<SkillResponse> AddSkill([FromRoute]int profileId, [FromBody]SkillModel model)
        {
            try
            {
                var skill = this.context.Add(profileId, model);
                return this.CreatedAtRoute(nameof(GetSkill), new { profileId, skillName = skill.Name }, skill);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // POST: /api/profiles/{profileId}/skills/{skillName}
        [HttpPost("{profileId}/skills/{skillName}")]
        public ActionResult SetScore([FromRoute]int profileId, [FromRoute]string skillName, [FromBody, Range(0, 5)]int score)
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