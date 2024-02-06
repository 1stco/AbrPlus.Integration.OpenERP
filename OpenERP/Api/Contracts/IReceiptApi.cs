using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IReceipt</c> interface.
    /// <para>Interface for Receipt. contains methods to support Receipt. Creates a proxy for Receipt.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="PaymentBundle"/>
    [ServiceContract]
    public interface IReceiptApi : IBaseIntegrationApi<PaymentBundle>
    {
    }
}
