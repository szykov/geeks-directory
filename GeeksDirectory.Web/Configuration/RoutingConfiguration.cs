using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;

namespace GeeksDirectory.Web.Configuration
{
    public static class RoutingConfiguration
    {
        public static IServiceCollection AddPredefinedRouting(this IServiceCollection services)
        {
            services.AddControllersWithViews(setup =>
            {
                setup.Filters.Add(new ProducesResponseTypeAttribute(typeof(BadRequestErrorResponse), StatusCodes.Status400BadRequest));
                setup.Filters.Add(new ProducesResponseTypeAttribute(typeof(NotAllowedErrorResponse), StatusCodes.Status405MethodNotAllowed));
                setup.Filters.Add(new ProducesResponseTypeAttribute(typeof(NotAcceptableErrorResponse), StatusCodes.Status406NotAcceptable));
                setup.Filters.Add(new ProducesResponseTypeAttribute(typeof(InternalServerErrorResponse), StatusCodes.Status500InternalServerError));

                setup.Filters.Add(new AuthorizeFilter());

                setup.ReturnHttpNotAcceptable = true;

                var jsonOutputFormatter = setup.OutputFormatters
                    .OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

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
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest)
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressMapClientErrors = true;
            });

            // Enforce lower case URL routing
            services.AddRouting(options => options.LowercaseUrls = true);

            return services;
        }

        public static IApplicationBuilder UsePredefinedRouting(this IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
