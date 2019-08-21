using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using System.Linq;

namespace GeeksDirectory.Web.Configuration
{
    public static class RoutingConfiguration
    {
        public static IServiceCollection AddPredefinedRouting(this IServiceCollection services)
        {
            services.AddMvc(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;

                var jsonOutputFormatter = setup.OutputFormatters
                    .OfType<JsonOutputFormatter>().FirstOrDefault();

                if (jsonOutputFormatter != null)
                {
                    // remove text/json as it isn't the approved media type
                    // for working with JSON at API level
                    if (jsonOutputFormatter.SupportedMediaTypes.Contains("text/json"))
                    {
                        jsonOutputFormatter.SupportedMediaTypes.Remove("text/json");
                    }
                }
            })
            .AddJsonOptions(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Enforce lower case URL routing
            services.AddRouting(options => options.LowercaseUrls = true);

            return services;
        }

        public static IApplicationBuilder UsePredefinedRouting(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
