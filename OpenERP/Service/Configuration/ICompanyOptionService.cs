using AbrPlus.Integration.OpenERP.Settings;
using System;
using System.Text;

namespace AbrPlus.Integration.OpenERP.Service.Configuration
{
    public interface ICompanyOptionService<TCompanyConfig> where TCompanyConfig : BaseFlatCompanyConfig
    {
        TCompanyConfig GetCompanyFlatConfig(int companyId);
    }
}
