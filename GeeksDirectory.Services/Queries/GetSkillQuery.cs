using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetSkillQuery : IRequest<SkillResponse?>
    {
        public readonly int ProfileId;
        public readonly int SkillId;

        public GetSkillQuery(int profileId, int skillId) =>
            (this.ProfileId, this.SkillId) = (profileId, skillId);
    }
}
