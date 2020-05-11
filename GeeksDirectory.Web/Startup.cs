using GeeksDirectory.Domain.Extensions;
using GeeksDirectory.Web.Configuration;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;

namespace GeeksDirectory.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IEnumerable<string> origins;
        private readonly string connectionString;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.origins = this.configuration.GetSection("AllowOrigins").Get<IEnumerable<string>>();
            this.connectionString = this.configuration.GetConnectionString("DefaultConnection");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPredefinedServices(this.connectionString);

            if (this.origins.NotNullOrEmpty())
                services.AddPredefinedCors(this.origins);

            services.AddPredefinedApiVersioning();
            services.AddPredefinedSwagger();
            services.AddPredefinedOpenIddict(this.connectionString);

            services.AddPredefinedRouting();
            services.AddPredefinedSpa();

            services.AddPredefinedApplicationCookie();

            services.AddPredefinedErrorHandling();

            services.AddPredefinedDapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (this.origins.NotNullOrEmpty())
                app.UsePredefinedCors();

            app.UseAuthentication();
            app.UsePredefinedErrorHandling(env);
            app.UsePredefinedRouting();
            app.UsePredefinedSwagger();
            app.UsePredefinedSpa();
        }
    }
}
