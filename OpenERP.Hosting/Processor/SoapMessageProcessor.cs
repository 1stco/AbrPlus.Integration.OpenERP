using AbrPlus.Integration.OpenERP.Hosting.Hosting;
using AbrPlus.Integration.OpenERP.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SeptaKit.Extensions;
using SoapCore.Extensibility;
using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbrPlus.Integration.OpenERP.Hosting.Processor
{
    public class SoapMessageProcessor : ISoapMessageProcessor
    {
        public async Task<Message> ProcessMessage(Message message, HttpContext context, Func<Message, Task<Message>> next)
        {
            using (MessageBuffer mb = message.CreateBufferedCopy(int.MaxValue))
            {
                Message responseMsg = mb.CreateMessage();
                message = mb.CreateMessage();

                using (var reader = responseMsg.GetReaderAtBodyContents())
                {
                    XDocument doc = XDocument.Load(reader.ReadSubtree());

                    var elements = doc.Descendants();

                    var companyIdString = elements.FirstOrDefault(c => string.Equals(c.Name.LocalName, ParameterConst.CompanyId, StringComparison.OrdinalIgnoreCase))?.Value;

                    if (companyIdString.HasValue() && int.TryParse(companyIdString, out int companyId))
                    {
                        var companyContext = context.RequestServices.GetService<ICompanyContext>();
                        companyContext.SetCompanyId(companyId);
                    }
                }

                return await next.Invoke(message);
            }
        }
    }


}
