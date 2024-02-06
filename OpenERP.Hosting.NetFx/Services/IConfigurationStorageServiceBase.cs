using AbrPlus.Integration.OpenERP.Settings;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx.Services
{
    public interface IConfigurationStorageServiceBase<TFinancialSystemSpecificModel>
        where TFinancialSystemSpecificModel : class, new()
    {
        void DeleteCompany(int companyId);
        CompanyConfig GetCompanyConfig(int companyId);
        FinancialSystemConfig GetConfig();
        FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId);
        void RemoveFinancialSystem();
        void SetCompanyConfig(CompanyConfig companyConfig);
        void SetConfig(FinancialSystemConfig config);
        void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs);
    }
}
