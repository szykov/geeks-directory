using AutoMapper;

using GeeksDirectory.SharedTypes.Mappings;
using GeeksDirectory.Web.Services.Interfaces;

namespace GeeksDirectory.Web.Services
{
    public class MapperService : IMapperService
    {
        public IMapper GetExceptionResponseMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExceptionResponseMapProfile>();
            });

            return new Mapper(config);
        }
    }
}
