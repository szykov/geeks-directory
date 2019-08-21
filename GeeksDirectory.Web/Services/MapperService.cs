using AutoMapper;

using GeeksDirectory.SharedTypes.Mappings;
using GeeksDirectory.Web.Services.Interfaces;

namespace GeeksDirectory.Web.Services
{
    public class MapperService : IMapperService
    {
        public IMapper GetExceptionMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExceptionMapProfile>();
            });

            return new Mapper(config);
        }

        public IMapper GetGeekProfileMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeekProfileMapProfile>();
            });

            return new Mapper(config);
        }

        public IMapper GetSkillMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SkillMapProfile>();
            });

            return new Mapper(config);
        }
    }
}
