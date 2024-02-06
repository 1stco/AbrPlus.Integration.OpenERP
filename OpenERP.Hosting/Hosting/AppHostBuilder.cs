using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using SeptaKit.Extensions;

namespace AbrPlus.Integration.OpenERP.Hosting.Hosting
{
    public static class AppHostBuilder
    {
        public static IHostBuilder CreateHostBuilder<T>(string[] args, Func<IServiceProvider, int> getHttpPort, Func<IServiceProvider, int> getHttpsPort, Func<IServiceProvider, X509Certificate2> getCert, bool useLinuxService = false, bool useIIS = false, bool useAutoFac = true, bool hostLess = false) where T : class
        {
            getHttpPort.CheckArgumentIsNull(nameof(getHttpPort));
            getHttpsPort.CheckArgumentIsNull(nameof(getHttpsPort));
            getCert.CheckArgumentIsNull(nameof(getCert));


            var host = Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseContentRoot(GetAppLocation())
            .ConfigSettings()
            .UseSerilog((hostBuilder, serviceProvider, log) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                log.ReadFrom.Configuration(configuration);
            });

#if !DEBUG
            if (hostLess)
            {
                object instance = new();

                host.ConfigureServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    instance = ActivatorUtilities.CreateInstance(sp, typeof(T));
                    typeof(T).GetMethod("ConfigureServices").Invoke(instance, new object[] { services });
                }).ConfigureContainer<ContainerBuilder>(container =>
                {
                    typeof(T).GetMethod("ConfigureContainer").Invoke(instance, new object[] { container });
                }).UseWindowsService();
            }
            else
            {
                if (useIIS)
                {
                    host.ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder
                        .UseStartup<T>()
                        .UseIIS();
                    });

                }
                else if (useLinuxService)
                {
                    host.UseSystemd();
                    if (!hostLess)
                    {
                        host.ConfigureWebHostDefaults(webBuilder =>
                         {
                             webBuilder
                             .UseStartup<T>()
                             .UseKestrel(opts =>
                             {
                                 opts.BuildKestrel(getHttpPort, getHttpsPort, getCert, useIIS);
                             });
                         });
                    }
                }
                else
                {
                    host.UseWindowsService();
                    if (!hostLess)
                    {
                        host.ConfigureWebHostDefaults(webBuilder =>
                         {
                             webBuilder
                             .UseStartup<T>()
                             .UseKestrel(opts =>
                             {
                                 opts.BuildKestrel(getHttpPort, getHttpsPort, getCert, useIIS);
                             });

                         });
                    }

                }
            }
#else

            if (hostLess)
            {
                object instance = new object();

                host.ConfigureServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    instance = ActivatorUtilities.CreateInstance(sp, typeof(T));
                    typeof(T).GetMethod("ConfigureServices").Invoke(instance, new object[] { services });
                }).ConfigureContainer<ContainerBuilder>(container =>
                {
                    typeof(T).GetMethod("ConfigureContainer").Invoke(instance, new object[] { container });
                });
            }
            else
            {
                host.ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                     .UseStartup<T>()
                     .UseKestrel(opts =>
                     {
                         opts.BuildKestrel(getHttpPort, getHttpsPort, getCert, useIIS);
                     });
                });
            }

#endif

            return host;
        }

        private static void BuildKestrel(this KestrelServerOptions opts, Func<IServiceProvider, int> getHttpPort, Func<IServiceProvider, int> getHttpsPort, Func<IServiceProvider, X509Certificate2> getCert, bool useIIS)
        {
            var httpPort = getHttpPort.Invoke(opts.ApplicationServices);
            var httpsPort = getHttpsPort.Invoke(opts.ApplicationServices);

            if (httpPort == 0 && httpsPort == 0)
            {
                throw new Exception("No port is configured!!!");
            }

            if (httpPort > 0)
            {
                opts.ListenAnyIP(httpPort, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                });
            }

            if (httpPort > 0)
            {
                opts.ListenAnyIP(httpsPort, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                    if (!useIIS)
                    {
                        listenOptions.UseHttps(getCert(opts.ApplicationServices));
                    }
                });
            }
        }

        public static string GetAppLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }

}
