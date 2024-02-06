namespace AbrPlus.Integration.OpenERP.Service
{
    public class CompanyContext : ICompanyContext
    {
        public int CompanyId { get; private set; }

        public void SetCompanyId(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
