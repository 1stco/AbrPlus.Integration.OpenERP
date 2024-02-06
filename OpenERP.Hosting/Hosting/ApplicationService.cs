using Microsoft.Extensions.DependencyInjection;
using System;

namespace AbrPlus.Integration.OpenERP.Hosting.Hosting
{
    public static class ApplicationService
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static object GetInstance(Type type)
        {
            return ServiceProvider.GetRequiredService(type);
        }
    }

}
