namespace AbrPlus.Integration.OpenERP.Service.Configuration
{
    public interface IConnectionStringValidator
    {
        bool Validate(string dataSource, bool integratedSecurity, string userId, string password, out string message);
    }
}