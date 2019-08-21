using AutoMapper;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface IMapperService
    {
        IMapper GetExceptionMapper();

        IMapper GetGeekProfileMapper();

        IMapper GetSkillMapper();
    }
}