using GeeksDirectory.Domain.Responses;

using MediatR;

using System;

namespace GeeksDirectory.Services.Queries
{
    public class GetSkillEvaluationQuery : IRequest<AssessmentResponse?>
    {
        public readonly long SkillId;
        public readonly Guid UserId;

        public GetSkillEvaluationQuery(long skillId, Guid userId) =>
            (this.SkillId, this.UserId) = (skillId, userId);
    }
}
