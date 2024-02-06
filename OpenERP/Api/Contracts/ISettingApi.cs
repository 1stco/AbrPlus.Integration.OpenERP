using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Settings;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.Contracts
{
    /// <summary>
    /// The main <c>ISetting</c> interface.
    /// Defines methods to support the SettingService.
    /// </summary>
    [ServiceContract]
    public interface ISettingApi
    {
        /// <summary>
        /// Remove Financial System
        /// </summary>
        [OperationContract]
        void DeleteFinancialSystem();

        /// <summary>
        /// Returns Finacial system config.
        /// </summary>
        /// <returns>Config</returns>
        /// <see cref="FinancialSystemConfig"/>
        [OperationContract]
        FinancialSystemConfig GetFinancialSystemConfig();

        /// <summary>
        /// Sets Financial system config.
        /// </summary>
        /// <param name="config">Config</param>
        /// <see cref="FinancialSystemConfig"/>
        [OperationContract]
        void SetFinancialSystemConfig(FinancialSystemConfig config);

        /// <summary>
        /// Gets Company config
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns>Config</returns>
        /// <see cref="CompanyConfig"/>
        [OperationContract]
        CompanyConfig GetCompanyConfig(int companyId);

        /// <summary>
        /// Sets company config
        /// </summary>
        /// <param name="companyConfig">Company config</param>
        /// <see cref="CompanyConfig"/>
        [OperationContract]
        void SetCompanyConfig(CompanyConfig companyConfig);

        /// <summary>
        /// Gets Company Id and Delete company from <c>configStorageService</c>.
        /// </summary>
        /// <param name="companyId">Company Id</param>
        [OperationContract]
        void DeleteCompany(int companyId);

        /// <summary>
        /// Gets company Id and Returns Financial System Specific Configs
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns> Financial System Specific Configs</returns>
        /// <see cref="FinancialSystemSpecificConfig"/>
        [OperationContract]
        FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId);

        /// <summary>
        /// Gets company id and configs, Sets financial system specific configs
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="configs">Configs</param>
        /// <see cref="FinancialSystemSpecificConfig"/>
        [OperationContract]
        void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs);

        ///// <summary>
        ///// Retuns Setting by company id.
        ///// </summary>
        ///// <param name="companyId">Company Id</param>
        ///// <returns>Setting</returns>
        ///// <see cref="Setting"/>
        //[OperationContract]
        //Setting[] GetSettings(int companyId);

        ///// <summary>
        ///// Gets new setting and sets them.
        ///// </summary>
        ///// <param name="settings">Settings</param>
        ///// <see cref="Setting"/>
        //[OperationContract]
        //void SetSettings(Setting[] settings);

        /// <summary>
        /// Gets company Id and returns information.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>System information bundle</returns>
        [OperationContract]
        SystemInfoBundle GetInfo(int companyId);

        /// <summary>
        /// Gets settings and test financial system settings
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        /// <see cref="SettingsTestResult"/>
        /// <seealso cref="FinancialSystemSettings"/>
        [OperationContract]
        SettingsTestResult TestFinancialSystemSettings(FinancialSystemSettings settings);

        /// <summary>
        /// Gets company id and returns current fiscal year
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        [OperationContract]
        int GetCurrentFiscalYear(int companyId);
    }
}
