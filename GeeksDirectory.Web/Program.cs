#pragma warning disable CA1052

using GeeksDirectory.Web.Configuration;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

using NLog.Web;

using System;

namespace GeeksDirectory.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UsePredefinedAppConfiguration(args);
                webBuilder.ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     logging.AddDebug();
                     logging.AddConsole();
                     logging.ClearProviders();
                 });
                webBuilder.UseNLog();
            });
    }
}
