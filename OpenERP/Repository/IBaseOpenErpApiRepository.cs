using SeptaKit.Models;
using SeptaKit.Repository;
using System;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Repository
{
    public interface IBaseOpenErpApiRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
    }

    public interface IBaseOpenErpApiRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task DisableIdentityInsertAsync();
        Task EnableIdentityInsertAsync();
    }
}
