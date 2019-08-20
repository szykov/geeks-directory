using GeeksDirectory.Data;
using GeeksDirectory.Data.Entities;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeeksDirectory.Web.Configuration
{
    public static class OpenIddictConfiguration
    {
        public static IServiceCollection AddPredefinedOpenIddict(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(connectionString);

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

            // Register the Identity services.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Register the OpenIddict services.
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and entities.
                    options.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>();
                })

                .AddServer(options =>
                {
                    // Register the ASP.NET Core MVC binder used by OpenIddict.
                    // Note: if you don't call this method, you won't be able to
                    // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                    options.UseMvc();

                    // During development, you can disable the HTTPS requirement.
                    options.DisableHttpsRequirement();

                    // Accept token requests that don't specify a client_id.
                    options.AcceptAnonymousClients();
                })

                .AddValidation();

            return services;
        }
    }
}
