using AbrPlus.Integration.OpenERP.Api.DataContracts;
using AbrPlus.Integration.OpenERP.Settings;
using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Service.Configuration
{
    public interface ICompanySettingService<TCompanySettingType>
    {
        List<SettingValue> GetCompanySetting(int companyId, TCompanySettingType companySettingType);
        FinancialSystemSpecificConfig[] GetFinancialSystemSpecificConfigs(int companyId);
        void SetFinancialSystemSpecificConfigs(int companyId, FinancialSystemSpecificConfig[] configs);
    }
}
