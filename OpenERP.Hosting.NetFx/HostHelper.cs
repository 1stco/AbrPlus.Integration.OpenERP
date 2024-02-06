using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeptaKit.Extensions;
using SeptaKit.Hosting;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System;
using System.IO;
using System.Linq;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx
{
    public static class HostHelper
    {
        public static int GetHttpPort(IServiceProvider serviceProvider)
        {
            var excetuingAssembly = Assembly.GetEntryAssembly();
            var configuration = serviceProvider.GetService<IConfiguration>();
            string assemblyName = excetuingAssembly.GetName().Name;
            return configuration.GetValue<int>($"Apis:{assemblyName}:HttpPort");
        }
        public static int GetHttpsPort(IServiceProvider serviceProvider)
        {
            var excetuingAssembly = Assembly.GetEntryAssembly();
            var configuration = serviceProvider.GetService<IConfiguration>();
            string assemblyName = excetuingAssembly.GetName().Name;
            return configuration.GetValue<int>($"Apis:{assemblyName}:Port");
        }
        public static X509Certificate2 GetCertificate(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var authorityCert = configuration.GetValue<string>($"AuthorityCert");
            if (authorityCert.HasValue())
            {
                using (var store = new X509Store(StoreName.Root.ToString(), StoreLocation.LocalMachine))
                {
                    store.Open(OpenFlags.ReadOnly);
                    return store.Certificates.Cast<X509Certificate2>().FirstOrDefault();
                }
            }
            else
            {
                var env = serviceProvider.GetService<IHostEnvironment>();
                return new X509Certificate2(Path.Combine(env.ContentRootPath, Path.Combine("Certs", "localhost.pfx")), "13");
            }
        }
        public static List<AppConfigSetting> GetAppConfigSettings<T>()
        {
            var basePath = AppContext.BaseDirectory;

            var appConfigSettings = new List<AppConfigSetting>()
            {
                new AppConfigSetting
                {
                    Path=Path.Combine(basePath, "Configs", "appsettings.global.json"),
                    Optional=false,
                    ReloadOnChange=true
                },
                new AppConfigSetting
                {
                    Path=Path.Combine(basePath, "Configs", "appsettings.json"),
                    Optional=false,
                    ReloadOnChange=true
                }
            };
            return appConfigSettings;
        }

    }

}
