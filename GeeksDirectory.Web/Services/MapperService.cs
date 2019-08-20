using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.SharedTypes.Mappings;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.Web.Services.Interfaces;

namespace GeeksDirectory.Web.Services
{
    public class MapperService : IMapperService
    {
        public IMapper GetExceptionMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExceptionResponseMapProfile>();
            });

            return new Mapper(config);
        }

        public IMapper GetGeekProfileMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GeekProfileModel, GeekProfile>();
            });

            return new Mapper(config);
        }
    }
}
