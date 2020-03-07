#pragma warning disable CS8602

using AutoMapper;

using GeeksDirectory.Domain.Responses;

using System;

namespace GeeksDirectory.Domain.Mappings
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
