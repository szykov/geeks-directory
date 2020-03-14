using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetSkillEvaluationQuery : IRequest<AssessmentResponse?>
    {
        public readonly int ProfileId;
        public readonly int SkillId;
        public readonly string UserId;

        public GetSkillEvaluationQuery(int profileId, int skillId, string userId) =>
            (this.ProfileId, this.SkillId, this.UserId) = (profileId, skillId, userId);
    }
}
