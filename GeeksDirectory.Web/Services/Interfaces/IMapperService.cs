using AutoMapper;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IMapperService
    {
        IMapper GetExceptionMapper();

        IMapper GetDataMapper();
    }
}