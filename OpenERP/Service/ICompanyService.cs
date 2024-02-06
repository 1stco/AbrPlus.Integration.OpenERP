using System;
using System.Collections.Generic;
using System.Text;

namespace AbrPlus.Integration.OpenERP.Service
{
    public interface ICompanyService<TVersion, TCompanyConfig>
    {
        void CheckVersionIsCompatible();
        string GetCurrentVersion();

        bool TryGetCompatibleVersion(out TVersion compatibleVersion, out string currentVersion);

        bool IsCurrentVersionCompatible();
        TCompanyConfig GetCompanyConfig();
    }
}
