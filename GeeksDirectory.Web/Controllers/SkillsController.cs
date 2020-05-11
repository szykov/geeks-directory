using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Notifications;
using GeeksDirectory.Services.Queries;
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
     * <summary>Skills controller with actions related to skills</summary>
     * <remarks>CRUD operations regarding skills.</remarks>
    **/
    [ApiController]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    [Route("api/profiles")]
    [ApiVersion("1.0")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class SkillsController : BaseApiController
    {
        private readonly IMediator mediator;
        private readonly ILogger logger;

        public SkillsController(IMediator mediator, ILogger<ProfilesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        // GET: /api/profiles/skills/{skillId}
        /**
         * <summary>Get skill</summary>
         * <remarks>Get profile's skill by it's name.</remarks>
         * <param name="skillId">Skill's id</param>
         * <returns>Matched skill</returns>
        **/
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("skills/{skillId}", Name = "GetSkill")]
        public async Task<ActionResult<SkillResponse>> GetSkill([FromRoute]int skillId)
        {
            var query = new GetSkillQuery(skillId);
            var skill = await this.mediator.Send(query);

            return this.Ok(skill);
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
        public async Task<ActionResult<SkillResponse>> RegisterSkillAsync([FromRoute]int profileId, [FromBody]SkillModel model)
        {
            var command = new RegisterSkillCommand(profileId, model);
            var result = await this.mediator.Send(command);

            if (result.IsFailed)
                return this.UnprocessableEntity(result);

            var user = await this.mediator.Send(new GetCurrentUserQuery());

            var notification = new EvaluateSkillNotification(user.Id, result.Value, model.Score);
            await this.mediator.Publish(notification);

            var query = new GetSkillQuery(result.Value);
            var skill = await this.mediator.Send(query);

            return CreatedAtRoute(nameof(GetSkill), new { skillId = skill!.Id }, skill);
        }

        // POST: /api/profiles/skills/{skillId}/score
        /**
         * <summary>Evaluate skill</summary>
         * <remarks>Evaluate profile's skill.</remarks>
         * <param name="skillId">Skill's id</param>
         * <param name="model">Skill Evaluation model</param>
         * <returns>Updated skill's average score</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("skills/{skillId}/score")]
        public async Task<ActionResult<SkillResponse>> EvaluateSkillAsync([FromRoute]int skillId, [FromBody]SkillEvaluationModel model)
        {
            var user = await this.mediator.Send(new GetCurrentUserQuery());

            var notification = new EvaluateSkillNotification(user.Id, skillId, model.Score);
            await this.mediator.Publish(notification);

            var query = new GetSkillQuery(skillId);
            var skill = await this.mediator.Send(query);

            return this.Ok(skill);
        }

        // GET: /api/profiles/skills/{skillId}/score
        /**
         * <summary>Get previous skill evaluation</summary>
         * <remarks>Try to get previous skill evaluation if such exists</remarks>
         * <param name="skillId">Skill's id</param>
         * <returns>Assessment data with your score</returns>
        **/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("skills/{skillId}/score")]
        public async Task<ActionResult<AssessmentResponse?>> GetMySkillEvaluationAsync([FromRoute]int skillId)
        {
            var user = await this.mediator.Send(new GetCurrentUserQuery());

            var query = new GetSkillEvaluationQuery(skillId, user.Id);
            var assessment = await this.mediator.Send(query);

            if (assessment == null) 
                return this.NoContent();

            return this.Ok(assessment);
        }
    }
}