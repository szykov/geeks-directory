using GeeksDirectory.Infrastructure;
using GeeksDirectory.Infrastructure.Repositories;
using GeeksDirectory.Domain.Interfaces;
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
            services.AddMediatR(typeof(GeeksDirectory.Services.Queries.GetProfilesQuery).Assembly);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

            services.AddSingleton<IMapperService, MapperService>();

            services.AddScoped<IProfilesRepository, ProfilesRepository>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<IAssessmentsRepository, AssessmentsRepository>();

            return services;
        }
    }
}
