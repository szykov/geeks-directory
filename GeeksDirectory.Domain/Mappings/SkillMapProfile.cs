using AutoMapper;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Models;
using GeeksDirectory.Domain.Responses;

namespace GeeksDirectory.Domain.Mappings
{
    public class SkillMapProfile : Profile
    {
        public SkillMapProfile()
        {
            this.CreateMap<SkillModel, Skill>();

            this.CreateMap<Skill, SkillResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
