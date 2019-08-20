using GeeksDirectory.Data;
using GeeksDirectory.SharedTypes.Extensions;
using GeeksDirectory.Web.Configuration;
using GeeksDirectory.Web.Services;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;

namespace GeeksDirectory.Web
{
    public class Startup
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IEnumerable<string> origins;
        private readonly IHostingEnvironment environment;
        private string connectionString;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment environment)
        {
            this.logger = loggerFactory.CreateLogger<Startup>();
            this.configuration = configuration;
            this.origins = this.configuration.GetSection("AllowOrigins").Get<IEnumerable<string>>();
            this.environment = environment;
            this.connectionString = this.configuration.GetConnectionString("DefaultConnection");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPredefinedOpenIddict(this.connectionString);

            if (this.origins.NotNullOrEmpty())
            {
                services.AddPredefinedCors(this.origins);
            }

            services.AddPredefinedRouting();

            services.AddPredefinedErrorHandling(this.logger);

            services.AddPredefinedSpa();

            //  Services
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.connectionString));

            services.AddScoped<IMapperService, MapperService>();

            services.AddScoped<IProfilesService, ProfilesService>();
            services.AddScoped<ISkillsService, SkillsService>();

            services.AddPredefinedApplicationCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (this.origins.NotNullOrEmpty())
            {
                app.UsePredefinedCors();
            }

            app.UsePredefinedErrorHandling(env);

            app.UsePredefinedRouting();

            app.UsePredefinedSpa(env);
        }
    }
}
