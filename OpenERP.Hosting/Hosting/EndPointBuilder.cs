using Microsoft.AspNetCore.Builder;
using SoapCore;
using System.ServiceModel.Channels;
using System.Text;
using Microsoft.AspNetCore.Routing;
using System;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Hosting.Hosting
{
    public static class EndPointBuilder
    {
        public static void UseSoapEndPoint(this IEndpointRouteBuilder endpoints, Type endpointType)
        {
            var serviceName = endpointType.Name; // remove Api from serviceAddress

            endpoints.UseSoapEndpoint(endpointType, $"/{serviceName}", new SoapEncoderOptions() { WriteEncoding = Encoding.UTF8, MessageVersion = MessageVersion.Soap11 }, SoapSerializer.DataContractSerializer, true);

            //TextMessageEncodingBindingElement textBindingElement = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressingAugust2004, System.Text.Encoding.UTF8);
            //HttpTransportBindingElement httpBindingElement = new HttpTransportBindingElement();
            //CustomBinding soap12Binding = new CustomBinding(textBindingElement, httpBindingElement);
            //endpoints.UseSoapEndpoint(endpointType, $"/{serviceName}", soap12Binding, SoapSerializer.DataContractSerializer, true, null, null, true, false);
        }

        public static void UseGrpcEndPoint(this IEndpointRouteBuilder endpoints, Type endpointType)
        {
            var grpcMethod = typeof(GrpcEndpointRouteBuilderExtensions).GetMethod("MapGrpcService").MakeGenericMethod(endpointType);
            grpcMethod.Invoke(null, new[] { endpoints });
        }

    }
}
