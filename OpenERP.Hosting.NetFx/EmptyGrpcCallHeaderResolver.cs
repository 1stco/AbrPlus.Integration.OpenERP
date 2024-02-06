using SeptaKit.ServiceModel.Grpc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx
{
    public class EmptyGrpcCallHeaderResolver : IGrpcCallHeaderResolver
    {
        public async Task<Dictionary<string, string>> GetHeaders()
        {
            return new Dictionary<string, string>();
        }
    }
}
