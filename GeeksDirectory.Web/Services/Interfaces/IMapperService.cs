using AutoMapper;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IMapperService
    {
        IMapper GetExceptionResponseMapper();
    }
}