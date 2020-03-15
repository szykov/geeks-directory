using FluentResults;

using GeeksDirectory.Domain.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class RegisterSkillCommand : IRequest<Result<long>>
    {
        public readonly long ProfileId;
        public readonly long SkillId;
        public readonly SkillModel Skill;

        public RegisterSkillCommand(long profileId, SkillModel skill) => 
            (this.ProfileId, this.Skill) = (profileId, skill);
    }
}
