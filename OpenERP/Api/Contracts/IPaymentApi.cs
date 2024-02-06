using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IPayment</c> interface.
    /// <para>Interface for payment. contains methods to support payment. Creates a proxy for payment.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="PaymentBundle"/>
    [ServiceContract]
    public interface IPaymentApi : IBaseIntegrationApi<PaymentBundle>
    {
    }
}
