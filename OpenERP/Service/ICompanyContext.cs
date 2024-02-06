using System;
using System.Collections.Generic;
using System.Text;

namespace AbrPlus.Integration.OpenERP.Service
{
    public interface ICompanyContext
    {
        int CompanyId { get; }

        void SetCompanyId(int companyId);
    }
}
