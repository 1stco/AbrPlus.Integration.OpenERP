using AbrPlus.Integration.OpenERP.Enums;
using AbrPlus.Integration.OpenERP.Hosting.Processor;
using AbrPlus.Integration.OpenERP.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeptaKit.ServiceModel.Grpc;
using ServiceModel.Grpc.Configuration;
using SoapCore;

namespace AbrPlus.Integration.OpenERP.Hosting.Hosting
{
    public static class ServiceCollectionBuilder
    {
        public static void GeneralConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.Configure<AppOption>(x => configuration.GetSection("App").Bind(x));

            services.AddDistributedMemoryCache();

            services.AddServiceModelGrpc(options =>
            {
                options.DefaultMarshallerFactory = MessagePackMarshallerFactory.Default;
                options.DefaultErrorHandlerFactory = serviceProvider => new UnexpectedExceptionServerHandler<OpenErpApiExceptionCode>();
                options.Filters.Add(1, provider => provider.GetRequiredService<IGrpcMessageProcessor>());
            });

            services.AddSoapCore();
            services.AddSoapMessageProcessor(new SoapMessageProcessor());

        }
    }
}
