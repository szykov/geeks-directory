using AutoMapper;

namespace GeeksDirectory.Services.Mappings
{
    public interface IMapperService
    {
        IMapper GetExceptionMapper();

        IMapper GetDataMapper();
    }
}