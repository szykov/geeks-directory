using GeeksDirectory.SharedTypes.DocumentFilters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GeeksDirectory.Web.Configuration
{
    public static class OpenApiSupport
    {
        public static IServiceCollection AddPredefinedSwagger(this IServiceCollection services)
        {
            var apiVersionDescriptionProvider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(setup =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setup.SwaggerDoc(description.GroupName,
                         new OpenApiInfo()
                         {
                             Title = "GeeksDirectory",
                             Version = description.ApiVersion.ToString(),
                             Description = "Geeks Directory - pick a geek or be one",
                             Contact = new OpenApiContact()
                             {
                                 Name = "Sergey Zykov",
                                 Url = new Uri("https://github.com/szykov")
                             }
                         });
                }

                setup.DocInclusionPredicate((documentName, apiDescription) =>
                {
                    var actionApiVersionModel = apiDescription.ActionDescriptor
                        .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

                    if (actionApiVersionModel is null)
                        return true;

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                        return actionApiVersionModel.DeclaredApiVersions.Any(v => v.ToString() == documentName);

                    return actionApiVersionModel.ImplementedApiVersions.Any(v => v.ToString() == documentName);
                });

                setup.DocumentFilter<UnauthorizedResponseDocumentFilter>();
                setup.DocumentFilter<ForbiddenResponseDocumentFilter>();

                setup.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Description = "Provide your clientId and clientSecret to access this API",
                    Flows = new OpenApiOAuthFlows()
                    {
                        Password = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri("/connect/token", uriKind: UriKind.Relative),
                            TokenUrl = new Uri("/connect/token", uriKind: UriKind.Relative)
                        },
                    }
                });

                setup.IncludeXmlComments(GetAssemblyFullPath(nameof(GeeksDirectory), nameof(Web)));
                setup.IncludeXmlComments(GetAssemblyFullPath(nameof(GeeksDirectory), nameof(SharedTypes)));

                setup.EnableAnnotations();
            });

            return services;
        }

        public static IApplicationBuilder UsePredefinedSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            return app;
        }

        private static string GetAssemblyFullPath(params string[] names)
        {
            var fullName = String.Join(".", names);
            var fileName = $"{Assembly.Load(fullName).GetName().Name}.xml";

            return Path.Combine(AppContext.BaseDirectory, fileName);
        }
    }
}
