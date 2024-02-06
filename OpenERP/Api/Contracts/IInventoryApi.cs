using AbrPlus.Integration.OpenERP.Api.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>   
    /// <para>The main <c>IInventory</c> Interface.</para>
    /// <para>Interface for inventory. Contains methods to support inventory.</para>
    /// </summary>


    [ServiceContract]
    public interface IInventoryApi
    {
        /// <summary>   Gets remaining stock from hamkaran repository. </summary>
        /// <param name="productCode">  The product code. </param>
        /// <param name="companyId">Using Which version of the hamkaran system repository</param>
        /// <returns>   The remaining stock. </returns>
        [OperationContract]
        List<RemainingStock> GetRemainingStock(string productCode, int companyId);
    }
}
