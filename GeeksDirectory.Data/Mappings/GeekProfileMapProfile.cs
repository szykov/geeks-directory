using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.SharedTypes.Mappings
{
    public class GeekProfileMapProfile : Profile
    {
        public GeekProfileMapProfile()
        {
            this.CreateMap<GeekProfileModel, GeekProfile>();
            this.CreateMap<CreateGeekProfileModel, GeekProfile>();

            this.CreateMap<GeekProfile, GeekProfileResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProfileId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));

            this.CreateMap<Skill, SkillResponse>();
        }
    }
}
