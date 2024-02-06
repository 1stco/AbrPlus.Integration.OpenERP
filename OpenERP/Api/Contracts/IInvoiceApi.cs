using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summmary>
    /// <para>The main <c>IInvoice</c> interface.</para>
    /// <para>Interface for invoice. contains methods to support Invoice. Creates a proxy for invoice.</para>
    /// </summmary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="InvoiceBundle"/>
    [ServiceContract]
    public interface IInvoiceApi : IBaseIntegrationApi<InvoiceBundle>
    {
        /// <summmary>   Synchronizes the with crm object type code described by companyId. </summary>
        /// <param name="companyId">Using Which version of the hamkaran system repository</param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        [OperationContract]
        bool SyncWithCrmObjectTypeCode(int companyId);

    }
}
