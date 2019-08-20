using AutoMapper;

using GeeksDirectory.Web.Configuration;
using GeeksDirectory.SharedTypes.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment environment)
        {
            this.logger = loggerFactory.CreateLogger<Startup>();
            this.configuration = configuration;
            this.origins = this.configuration.GetSection("AllowOrigins").Get<IEnumerable<string>>();
            this.environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (this.origins.NotNullOrEmpty())
            {
                services.AddPredefinedCors(this.origins);
            }

            services.AddPredefinedRouting();

            services.AddPredefinedErrorHandling(this.logger);

            services.AddPredefinedSpa();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
