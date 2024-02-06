using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <see cref="BundleBase"/>
    [ServiceContract]
    public interface IBaseIntegrationAsyncApi<T> where T : BundleBase
    {
        /// <summary>
        /// If customer number is null, Returns True.
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="companyId">Company Id</param>
        /// <returns>Boolean</returns>
        [OperationContract]
        Task<bool> Save(T item, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastTrackedVersion"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [OperationContract]
        Task<ChangeInfo> GetChanges(string lastTrackedVersion, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [OperationContract]
        Task<T> GetBundle(string key, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> Validate(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="companyId"></param>
        [OperationContract]
        Task SetTrackingStatus(bool enabled, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [OperationContract]
        Task<string[]> GetAllIds(int? companyId);
    }
}
