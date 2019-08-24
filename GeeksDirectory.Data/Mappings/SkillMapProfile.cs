using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.Data.Mappings
{
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
            this.CreateMap<SkillModel, Skill>();

            this.CreateMap<Skill, SkillResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SkillId));
        }
    }
}
