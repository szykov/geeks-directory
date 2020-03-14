using FluentResults;

using GeeksDirectory.Domain.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class RegisterSkillCommand : IRequest<Result<int>>
    {
        public readonly int ProfileId;
        public readonly int SkillId;
        public readonly SkillModel Skill;

        public RegisterSkillCommand(int profileId, SkillModel skill) => 
            (this.ProfileId, this.Skill) = (profileId, skill);
    }
}
