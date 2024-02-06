using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IReturnInvoice</c> interface.
    /// <para>Interface for ReturnInvoice. contains methods to support ReturnInvoice. Creates a proxy for ReturnInvoice.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="InvoiceBundle"/>
    [ServiceContract]
    public interface IReturnInvoiceApi : IBaseIntegrationApi<InvoiceBundle>
    {
        /// <summary>   Synchronizes the with crm object type code described by companyId. </summary>
        /// <param name="companyId">Using Which version of the hamkaran system repository.</param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        [OperationContract]
        bool SyncWithCrmObjectTypeCode(int companyId);
    }
}
