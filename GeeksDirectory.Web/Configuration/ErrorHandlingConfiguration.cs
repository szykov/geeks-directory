using GeeksDirectory.Web.Extensions;
using GeeksDirectory.Web.Midlewares;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GeeksDirectory.Web.Configuration
{
    public static class ErrorHandlingConfiguration
    {
        public static IServiceCollection AddPredefinedErrorHandling(this IServiceCollection services)
        {
            // Override modelstate
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errorResponse = context.ModelState.ToErrorResponse();

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }

        public static IApplicationBuilder UsePredefinedErrorHandling(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            if (env.IsProduction())
                app.UseExceptionHandler("/Error");

            app.UseEnvelopeErrorHandlingMiddleware();
            app.UseInternalServerErrorHandlingMiddleware();
            app.UseLogicErrorHandlingMiddleware();

            return app;
        }
    }
}
