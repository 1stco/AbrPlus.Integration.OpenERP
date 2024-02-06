using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IQuote</c> interface.
    /// <para>Interface for Quote. contains methods to support Quote. Creates a proxy for Quote.</para>
    /// </summary>
    /// <see cref="IBaseIntegrationApi{T}"/>
    /// <seealso cref="InvoiceBundle"/>
    [ServiceContract]
    public interface IQuoteApi : IBaseIntegrationApi<InvoiceBundle>
    {
        /// <summary>   Synchronizes the with crm object type code described by companyId. </summary>
        /// <param name="companyId">Using Which version of the hamkaran system repository.</param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        [OperationContract]
        bool SyncWithCrmObjectTypeCode(int companyId);
    }
}
