using GeeksDirectory.Domain.Responses;

using MediatR;

using System;

namespace GeeksDirectory.Services.Queries
{
    public class GetSkillEvaluationQuery : IRequest<AssessmentResponse?>
    {
        public readonly long ProfileId;
        public readonly long SkillId;
        public readonly Guid UserId;

        public GetSkillEvaluationQuery(long profileId, long skillId, Guid userId) =>
            (this.ProfileId, this.SkillId, this.UserId) = (profileId, skillId, userId);
    }
}
