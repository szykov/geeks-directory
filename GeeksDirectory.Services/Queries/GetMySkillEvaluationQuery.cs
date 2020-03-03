using FluentResults;

using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetMySkillEvaluationQuery : IRequest<AssessmentResponse?>
    {
        public readonly int ProfileId;
        public readonly string SkillName;

        public GetMySkillEvaluationQuery(int profileId, string skillName)
        {
            this.ProfileId = profileId;
            this.SkillName = skillName;
        }
    }
}
