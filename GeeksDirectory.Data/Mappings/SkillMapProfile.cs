using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.SharedTypes.Mappings
{
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
            this.CreateMap<SkillModel, Skill>();
            this.CreateMap<Skill, SkillResponse>();
        }
    }
}
