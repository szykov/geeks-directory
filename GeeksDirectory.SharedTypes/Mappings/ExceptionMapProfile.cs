using AutoMapper;

using GeeksDirectory.SharedTypes.Responses;

using System;

namespace GeeksDirectory.SharedTypes.Mappings
{
    public class ExceptionMapProfile : Profile
    {
        public ExceptionMapProfile()
        {
            this.CreateMap<Exception, ErrorResponse>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.InnerException.GetType().Name))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .IncludeAllDerived();
        }
    }
}
