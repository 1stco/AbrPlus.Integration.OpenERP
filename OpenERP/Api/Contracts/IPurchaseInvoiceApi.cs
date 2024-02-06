using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IPurchaseInvoice</c> interface.
    /// <para>Interface for PurchaseInvoice. contains methods to support PurchaseInvoice. Creates a proxy for PurchaseInvoice.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="InvoiceBundle"/>
    [ServiceContract]
    public interface IPurchaseInvoiceApi : IBaseIntegrationApi<InvoiceBundle>
    {
    }
}
