using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using System.Linq;

using GeeksDirectory.SharedTypes.Extensions;

namespace GeeksDirectory.Web.Configuration
{
    public static class CorsConfiguration
    {
        private const string policyName = "CORS";

        public static IServiceCollection AddPredefinedCors(this IServiceCollection services, IEnumerable<string> webUrls)
        {
            if (!webUrls.IsNullOrEmpty())
            {
                services.AddCors(options =>
                {
                    options.AddPolicy(policyName,
                    builder =>
                    {
                        builder.WithOrigins(webUrls.ToArray())
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
                });
            }

            return services;
        }

        public static IApplicationBuilder UsePredefinedCors(this IApplicationBuilder app)
        {
            app.UseCors(policyName);

            return app;
        }
    }
}
