using AbrPlus.Integration.OpenERP.Hosting.Hosting;
using AbrPlus.Integration.OpenERP.Service;
using Microsoft.Extensions.Logging;
using ServiceModel.Grpc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Hosting.Processor
{
    public class GrpcMessageProcessor : IGrpcMessageProcessor
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ICompanyContext _companyContext;

        public GrpcMessageProcessor(ILoggerFactory loggerFactory, ICompanyContext companyContext)
        {
            _loggerFactory = loggerFactory;
            _companyContext = companyContext;
        }
        public async ValueTask InvokeAsync(IServerFilterContext context, Func<ValueTask> next)
        {
            var logger = _loggerFactory.CreateLogger(context.ServiceInstance.GetType().Name);

            try
            {
                var parameter = context.Request.FirstOrDefault(c => c.Key == ParameterConst.CompanyId);

                if (!parameter.Equals(default(KeyValuePair<string, object>)))
                {
                    var companyId = (int)parameter.Value;

                    _companyContext.SetCompanyId(companyId);
                }

                // invoke all other filters in the stack and the service method
                await next().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError("error {0} failed: {1}", context.ContractMethodInfo.Name, ex);
                throw;
            }
        }
    }


}
