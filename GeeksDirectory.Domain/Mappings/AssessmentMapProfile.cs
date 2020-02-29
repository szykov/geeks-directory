using AutoMapper;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Responses;

namespace GeeksDirectory.Domain.Mappings
{
    public class AssessmentMapProfile : Profile
    {
        public AssessmentMapProfile()
        {
            this.CreateMap<Assessment, AssessmentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AssessmentId))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
