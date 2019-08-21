using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.SharedTypes.Mappings
{
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
            this.CreateMap<Skill, SkillResponse>();
        }
    }
}
