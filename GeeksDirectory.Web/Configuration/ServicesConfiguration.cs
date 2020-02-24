using GeeksDirectory.Data;
using GeeksDirectory.Data.Repositories;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.Services.Mappings;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeeksDirectory.Web.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddPredefinedServices(this IServiceCollection services, string connectionString)
        {
            services.AddMediatR(typeof(GeeksDirectory.Services.DummyClass));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

            services.AddScoped<IMapperService, MapperService>();

            services.AddScoped<IProfilesRepository, ProfilesRepository>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<IAssessmentsRepository, AssessmentsRepository>();

            return services;
        }
    }
}
