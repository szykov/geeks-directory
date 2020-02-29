#pragma warning disable CA1307

using GeeksDirectory.Domain.Classes;

using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;

namespace GeeksDirectory.Web.Configuration
{
    public static class CookieConfiguration
    {
        public static IServiceCollection AddPredefinedApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(config =>
            {
                config.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api"))
                            ctx.Response.StatusCode = (int)ExceptionCode.Unauthorized;
                        else
                            ctx.Response.Redirect(ctx.RedirectUri);

                        return Task.FromResult(0);
                    }
                };
            });

            return services;
        }
    }
}
