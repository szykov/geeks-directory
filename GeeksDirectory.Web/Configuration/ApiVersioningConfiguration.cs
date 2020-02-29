using GeeksDirectory.Domain.Classes;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace GeeksDirectory.Web.Configuration
{
    public static class ApiVersioningConfiguration
    {
        public static IServiceCollection AddPredefinedApiVersioning(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(setupAction =>
            {
                setupAction.GroupNameFormat = "VV";
            });

            services.AddApiVersioning(setup =>
            {
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.ReportApiVersions = true;
                setup.ErrorResponses = new CustomErrorResponseProvider();
                setup.ApiVersionSelector = new DefaultApiVersionSelector(setup);
                setup.ApiVersionReader = ApiVersionReader.Combine(
                    new MediaTypeApiVersionReader(),
                    new HeaderApiVersionReader()
                    {
                        HeaderNames = { "api-version" }
                    });
            });

            return services;
        }
    }
}
