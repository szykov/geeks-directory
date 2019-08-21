using GeeksDirectory.SharedTypes.Extensions;
using GeeksDirectory.Web.Midlewares;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.Web.Configuration
{
    public static class ErrorHandlingConfiguration
    {
        public static IServiceCollection AddPredefinedErrorHandling(this IServiceCollection services, ILogger logger)
        {
            // Override modelstate
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errorResponse = context.ModelState.ToErrorResponse();
                    logger.LogWarning(new ValidationException(errorResponse.Message),
                        "In action {@action} model validation errors: {@modelErrors}.",
                        context.ActionDescriptor.DisplayName, errorResponse.Details);

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }

        public static IApplicationBuilder UsePredefinedErrorHandling(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCustomErrorHandlingMiddleware();
            app.UseInternalServerErrorHandlingMiddleware();

            return app;
        }
    }
}
