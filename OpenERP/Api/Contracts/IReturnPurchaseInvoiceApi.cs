using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IReturnPurchaseInvoice</c> interface.
    /// <para>Interface for ReturnPurchaseInvoice. contains methods to support ReturnPurchaseInvoice. Creates a proxy for ReturnPurchaseInvoice.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="InvoiceBundle"/>
    [ServiceContract]
    public interface IReturnPurchaseInvoiceApi : IBaseIntegrationApi<InvoiceBundle>
    {
    }
}
