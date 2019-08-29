﻿using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;

using System.Reflection;

namespace GeeksDirectory.Web.Configuration
{
    public static class AppConfiguration
    {
        public static IWebHostBuilder UsePredefinedAppConfiguration(this IWebHostBuilder builder, string[] args)
        {
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                config.SetBasePath(env.ContentRootPath);
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                if (env.IsDevelopment())
                {
                    var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                    if (appAssembly != null)
                    {
                        config.AddUserSecrets(appAssembly, optional: true);
                    }
                }

                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            });

            return builder;
        }
    }
}
