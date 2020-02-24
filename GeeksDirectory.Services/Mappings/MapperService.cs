using AutoMapper;

using GeeksDirectory.Data.Mappings;
using GeeksDirectory.SharedTypes.Mappings;

namespace GeeksDirectory.Services.Mappings
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

        public IMapper GetDataMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeekProfileMapProfile>();
                cfg.AddProfile<SkillMapProfile>();
                cfg.AddProfile<AssessmentMapProfile>();
            });

            return new Mapper(config);
        }
    }
}
