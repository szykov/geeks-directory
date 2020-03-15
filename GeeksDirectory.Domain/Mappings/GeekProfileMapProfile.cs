using AutoMapper;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Models;
using GeeksDirectory.Domain.Responses;

namespace GeeksDirectory.Domain.Mappings
{
    public class GeekProfileMapProfile : Profile
    {
        public GeekProfileMapProfile()
        {
            this.CreateMap<GeekProfileModel, GeekProfile>();
            this.CreateMap<CreateGeekProfileModel, GeekProfile>();

            this.CreateMap<GeekProfile, GeekProfileResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
