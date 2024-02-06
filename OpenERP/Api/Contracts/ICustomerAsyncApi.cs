using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>IIntegrationBase</c> interface.
    /// Defines methods to support the Customers field.
    /// </summary>
    [ServiceContract]
    public interface ICustomerAsyncApi : IBaseIntegrationAsyncApi<IdentityBundle>
    {
        /// <summary>
        /// Gets key and company id, Return bundel.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="companyId">Company Id</param>
        /// <returns>Bundel</returns>
        [OperationContract]
        Task<IdentityBundle> GetBundleByCode(string key, int companyId);

        /// <summary>
        /// Gets Customer code and Company id, Returns Customer balance
        /// </summary>
        /// <param name="customerCode">Customer code</param>
        /// <param name="companyId">Company Id</param>
        /// <returns>Balance of customer</returns>
        [OperationContract]
        Task<decimal> GetCustomerBalance(string customerCode, int companyId);

        /// <summary>
        /// Gets all identity balance with <paramref name="companyId"/> and <paramref name="identityBalanceParams"/> parametrs
        /// </summary>
        /// <param name="identityBalanceParams">IdentityBalanceParams like CustomerNumbers and etc</param>
        /// <param name="companyId">Company Id</param>
        /// <returns>List of Identity Balance</returns>
        /// <see cref="IdentityBalance"/>
        /// <seealso cref="IdentityBalanceParams"/>
        [OperationContract]
        Task<List<IdentityBalance>> GetAllIdentityBalance(IdentityBalanceParams identityBalanceParams, int companyId);
    }
}
