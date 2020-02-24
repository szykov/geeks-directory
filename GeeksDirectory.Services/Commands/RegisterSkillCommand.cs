using FluentResults;

using GeeksDirectory.SharedTypes.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class RegisterSkillCommand : IRequest<Result>
    {
        public readonly int ProfileId;
        public readonly SkillModel Skill;

        public RegisterSkillCommand(int profileId, SkillModel skill)
        {
            this.ProfileId = profileId;
            this.Skill = skill;
        }
    }
}
