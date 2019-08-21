using GeeksDirectory.Data;
using GeeksDirectory.Data.Repositories;
using GeeksDirectory.Web.Services;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeeksDirectory.Web.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddPredefinedServices(this IServiceCollection services, string connectionString)
        {
            // Services
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IMapperService, MapperService>();

            services.AddScoped<IProfilesRepository, ProfilesRepository>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();

            services.AddScoped<IProfilesService, ProfilesService>();
            services.AddScoped<ISkillsService, SkillsService>();

            return services;
        }
    }
}
