using System.Data;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Repository
{
    public interface ITrackingSupportRepository
    {
        void DisableTableTracking();
        void EnableTableTracking();

        long GetCurrentTrackingVersion();
        Task<long> GetCurrentTrackingVersionAsync();

        DataTable GetTrackingChanges(long afterVersion);
        Task<DataTable> GetTrackingChangesAsync(long afterVersion);
    }
}
