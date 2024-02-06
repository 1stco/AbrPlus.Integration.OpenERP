using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IPurchaseQuote</c> interface.
    /// <para>Interface for PurchaseQuote. contains methods to support PurchaseQuote. Creates a proxy for PurchaseQuote.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="InvoiceBundle"/>
    [ServiceContract]
    public interface IPurchaseQuoteApi : IBaseIntegrationApi<InvoiceBundle>
    {
    }
}
