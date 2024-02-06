using AbrPlus.Integration.OpenERP.Hosting.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace AbrPlus.Integration.OpenERP.Hosting.Hosting
{
    public static class HostBuilderExtention
    {
        public static IHostBuilder ConfigSettings(this IHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                config.AddJsonFile(Path.Combine(basePath, "Configs", "appsettings.json"), optional: false, true);
                config.AddJsonFile(Path.Combine(basePath, "Configs", "appsettings.global.json"), optional: false, true);

            });
        }

        public static void Run(this IHostBuilder build)
        {
            var host = build.Build();
            ApplicationService.ServiceProvider = host.Services;
            host.Run();
        }
    }

}
