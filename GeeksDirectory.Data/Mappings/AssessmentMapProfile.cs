using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.Data.Mappings
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
