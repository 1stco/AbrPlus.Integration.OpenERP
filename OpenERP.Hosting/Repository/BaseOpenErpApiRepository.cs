using AbrPlus.Integration.OpenERP.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SeptaKit.Models;
using SeptaKit.Repository.EFCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Hosting.Repository
{
    public abstract class BaseOpenErpApiRepository<TContext, TEntity, TKey> : BaseRepository<TEntity, TKey>, IBaseOpenErpApiRepository<TEntity, TKey>
        where TContext : DbContext, IDbContext
        where TEntity : BaseEntity<TKey>
    {
        protected ILogger _logger;
        protected TContext _context => _dbContext as TContext;

        protected BaseOpenErpApiRepository(TContext dbContext, ILoggerFactory loggerFactory)
            : base(dbContext)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
        }
    }

    public abstract class BaseOpenErpApiRepository<TContext, TEntity> : BaseRepository<TEntity>, IBaseOpenErpApiRepository<TEntity>
        where TContext : DbContext, IDbContext
        where TEntity : BaseEntity
    {
        protected ILogger _logger;
        protected TContext _context => _dbContext as TContext;
        protected BaseOpenErpApiRepository(TContext dbContext, ILoggerFactory loggerFactory)
            : base(dbContext)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
        }


        /// <summary>Enables the table tracking. </summary>
        /// <param name="tableName">table name in database. </param>
        public void EnableTableTracking()
        {
            var dbName = new SqlConnectionStringBuilder(_context.Database.GetConnectionString()).InitialCatalog;
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var tableName = $"[{entityType.GetSchema()}].[{entityType.GetTableName()}]";

            string scriptDBTracking = string.Format("SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID('{0}')", dbName);
            DataTable trackingDBData = _dbContext.GetDataTable(scriptDBTracking);

            if (trackingDBData.Rows.Count == 0)
            {
                try
                {
                    string script = string.Format("ALTER DATABASE {0} SET CHANGE_TRACKING = ON (CHANGE_RETENTION = 5 DAYS, AUTO_CLEANUP = ON)", dbName);
                    _dbContext.ExecuteSqlCommand(script);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in EnableTableTracking");
                    throw;
                }
            }

            string scriptTableTracking = string.Format("SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID('{0}')", tableName);
            DataTable trackingTableData = _dbContext.GetDataTable(scriptTableTracking);

            if (trackingTableData.Rows.Count == 0)
            {
                try
                {
                    string scriptEnableTableTracking = string.Format("ALTER TABLE {0} ENABLE CHANGE_TRACKING WITH(TRACK_COLUMNS_UPDATED = OFF)", tableName);
                    _dbContext.ExecuteSqlCommand(scriptEnableTableTracking);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in EnableTableTracking");
                    throw;
                }
            }
        }

        public void DisableTableTracking()
        {
            var dbName = new SqlConnectionStringBuilder(_context.Database.GetConnectionString()).InitialCatalog;
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var tableName = $"[{entityType.GetSchema()}].[{entityType.GetTableName()}]";

            string scriptDBTracking = string.Format("SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID('{0}')", dbName);
            DataTable trackingDBData = _context.GetDataTable(scriptDBTracking);

            if (trackingDBData.Rows.Count == 0)
            {
                return;
            }


            string scriptTableTracking = string.Format("SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID('{0}')", tableName);
            DataTable trackingTableData = _context.GetDataTable(scriptTableTracking);

            if (trackingTableData.Rows.Count == 0)
            {
                return;
            }

            string scriptEnableTableTracking = string.Format("ALTER TABLE {0} DISABLE CHANGE_TRACKING", tableName);
            _context.ExecuteSqlCommand(scriptEnableTableTracking);
        }

        public long GetCurrentTrackingVersion()
        {
            var version = _context.GetSingleValue<long>("SELECT NewTableVersion = CHANGE_TRACKING_CURRENT_VERSION()");

            return version;
        }

        public async Task<long> GetCurrentTrackingVersionAsync()
        {
            var version = await _context.GetSingleValueAsync<long>("SELECT NewTableVersion = CHANGE_TRACKING_CURRENT_VERSION()");

            return version;
        }

        public DataTable GetTrackingChanges(long afterVersion)
        {
            var dbName = new SqlConnectionStringBuilder(_context.Database.GetConnectionString()).InitialCatalog;
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var tableName = $"[{entityType.GetSchema()}].[{entityType.GetTableName()}]";

            return _dbContext.GetDataTable($"select * from  CHANGETABLE(CHANGES {dbName}.{tableName},{afterVersion}) AS ChTbl");
        }

        public async Task<DataTable> GetTrackingChangesAsync(long afterVersion)
        {
            var dbName = new SqlConnectionStringBuilder(_context.Database.GetConnectionString()).InitialCatalog;
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var tableName = $"[{entityType.GetSchema()}].[{entityType.GetTableName()}]";

            return await _dbContext.GetDataTableAsync($"select * from  CHANGETABLE(CHANGES {dbName}.{tableName},{afterVersion}) AS ChTbl");
        }

        public async Task EnableIdentityInsertAsync()
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var tableName = $"[{entityType.GetSchema()}].[{entityType.GetTableName()}]";

            await _dbContext.ExecuteSqlCommandAsync($"SET IDENTITY_INSERT {tableName} ON");
        }

        public async Task DisableIdentityInsertAsync()
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            var tableName = $"[{entityType.GetSchema()}].[{entityType.GetTableName()}]";

            await _dbContext.ExecuteSqlCommandAsync($"SET IDENTITY_INSERT {tableName} OFF");
        }
    }
}
