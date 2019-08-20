using GeeksDirectory.SharedTypes.Extensions;
using GeeksDirectory.Web.Midlewares;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

                    logger.LogWarning("In action {0} model validation errors: {1}.", context.ActionDescriptor.DisplayName, context.ModelState);
                    return new UnprocessableEntityObjectResult(errorResponse);
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

                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCustomErrorHandlingMiddleware();
            app.UseInternalServerErrorHandlingMiddleware();

            return app;
        }
    }
}
