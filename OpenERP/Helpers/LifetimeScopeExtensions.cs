using AbrPlus.Integration.OpenERP.Service;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    public static class LifetimeScopeExtensions
    {
        public static ILifetimeScope BeginLifetimeScopeForCompany(this ILifetimeScope lifetimeScope, int companyId)
        {
            return lifetimeScope.BeginLifetimeScope(p =>
            {
                p.Register<ICompanyContext>(s =>
                {
                    var companyContext = new CompanyContext();
                    companyContext.SetCompanyId(companyId);
                    return companyContext;
                });
            });
        }
    }
}
