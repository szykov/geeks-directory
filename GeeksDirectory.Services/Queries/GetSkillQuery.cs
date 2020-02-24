using GeeksDirectory.SharedTypes.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeeksDirectory.Services.Queries
{
    public class GetSkillQuery : IRequest<SkillResponse>
    {
        public readonly int ProfileId;
        public readonly string SkillName;

        public GetSkillQuery(int profileId, string skillName)
        {
            this.ProfileId = profileId;
            this.SkillName = skillName;
        }
    }
}
