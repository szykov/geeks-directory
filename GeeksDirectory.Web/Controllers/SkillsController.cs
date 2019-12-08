using AutoMapper;

using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OpenIddict.Validation;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Controllers
{
    /**
     * <summary>Skills controller with actions related to skills</summary>
     * <remarks>CRUD operations regarding skills.</remarks>
    **/
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    [Route("api/profiles")]
    [ApiVersion("1.0")]
    [Consumes("application/json")]
    [Produces("application/json")]
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
        /**
         * <summary>Get skill</summary>
         * <remarks>Get skill profile's skill by it's name.</remarks>
         * <param name="profileId">User profile id</param>
         * <param name="skillName">Name of the skill</param>
         * <returns>Matched skill</returns>
        **/
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
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
        /**
         * <summary>Add skill</summary>
         * <remarks>Add skill to profile.</remarks>
         * <param name="profileId">User profile id</param>
         * <param name="model">Skill's model</param>
         * <returns>Added skill</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("{profileId}/skills")]
        public async Task<ActionResult<SkillResponse>> AddSkillAsync([FromRoute]int profileId, [FromBody]SkillModel model)
        {
            try
            {
                var userName = this.User.Identity.Name!;
                var skill = await this.context.AddAsync(profileId, model, userName);

                return this.CreatedAtRoute(nameof(GetSkill), new { profileId, skillName = skill.Name }, skill);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }

        // POST: /api/profiles/{profileId}/skills/{skillName}/score
        /**
         * <summary>Evaluate skill</summary>
         * <remarks>Evaluate skill for profile.</remarks>
         * <param name="profileId">User profile id</param>
         * <param name="skillName">Skill's name</param>
         * <param name="score">New score for skill</param>
         * <returns>Updated skill's average score</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("{profileId}/skills/{skillName}/score")]
        public async Task<ActionResult<int>> EvaluateSkillAsync([FromRoute]int profileId, [FromRoute]string skillName, [FromBody, Range(0, 5)]int score)
        {
            try
            {
                var userName = this.User.Identity.Name!;
                return await this.context.EvaluateSkillAsync(profileId, skillName, userName, score);
            }
            catch (LogicException ex)
            {
                this.logger.LogError(ex, "Unable to fetch list of profiles.");
                return this.StatusCode(ex.StatusCode, this.mapper.Map<ErrorResponse>(ex));
            }
        }
    }
}