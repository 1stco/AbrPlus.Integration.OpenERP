using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <see cref="BundleBase"/>
    [ServiceContract]
    public interface IBaseIntegrationApi<T> where T : BundleBase
    {
        /// <summary>
        /// If customer number is null, Returns True.
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="companyId">Company Id</param>
        /// <returns>Boolean</returns>
        [OperationContract]
        bool Save(T item, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastTrackedVersion"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [OperationContract]
        ChangeInfo GetChanges(string lastTrackedVersion, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [OperationContract]
        T GetBundle(string key, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Validate(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="companyId"></param>
        [OperationContract]
        void SetTrackingStatus(bool enabled, int? companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [OperationContract]
        string[] GetAllIds(int? companyId);
    }
}
