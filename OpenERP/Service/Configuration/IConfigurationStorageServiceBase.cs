using AbrPlus.Integration.OpenERP.Settings;

namespace AbrPlus.Integration.OpenERP.Service.Configuration
{
    public interface IConfigurationStorageServiceBase<TFinancialSystemSpecificModel> where TFinancialSystemSpecificModel : class
    {
        void DeleteCompany(int companyId);
        CompanyConfig GetCompanyConfig(int companyId);
        FinancialSystemConfig GetConfig();
        TFinancialSystemSpecificModel GetFinancialSpecificModel(int companyId);
        FinancialSystemSpecificConfig[] GetSpecificConfigs();
        void RemoveFinancialSystem();
        void SetCompanyConfig(CompanyConfig companyConfig);
        void SetConfig(FinancialSystemConfig config);
    }
}
