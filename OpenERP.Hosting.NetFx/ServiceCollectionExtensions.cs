using AbrPlus.Integration.OpenERP.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeptaKit.Caching;
using SeptaKit.ServiceModel.Grpc;
using SeptaKit.ServiceModel.Http;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGeneralHost(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSeptaGrpcClient<EmptyGrpcCallHeaderResolver, OpenErpApiExceptionCode>();
            services.AddSeptaHttpClient();

            #region client

            //services.Configure<AppOption>(x => configuration.GetSection("App").Bind(x));

            #endregion

            services.AddMemoryCache();
            services.AddCachingProviders();

            services.AddDistributedMemoryCache();
        }
    }
}
