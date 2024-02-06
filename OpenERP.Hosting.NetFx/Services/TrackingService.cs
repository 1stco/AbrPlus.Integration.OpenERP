using AbrPlus.Integration.OpenERP.Enums;
using AbrPlus.Integration.OpenERP.Hosting.NetFx;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx.Services
{
    /// <summary>   A service for accessing trackings information. </summary>
    public class TrackingService
    {
        ScriptExecute _scriptExe;
        ScriptExecute _scriptExePgIntegration;
        string _databaseName;
        bool FinancialSystemIsHamkaran = false;
        string connectionStr = string.Empty;

        /// <summary>Constructor. using coonection string to connect to the hamkaran system database.</summary>
        /// <param name="connectionString"> The connection string. </param>
        public TrackingService(string connectionString)
        {
            connectionStr = connectionString;
            _scriptExe = new ScriptExecute(connectionString);
            _databaseName = new SqlConnectionStringBuilder(connectionString).InitialCatalog;

            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder(connectionString);
            scb.InitialCatalog = "PgIntegration";
            _scriptExePgIntegration = new ScriptExecute(scb.ConnectionString);

            var finacialSystemType = _scriptExePgIntegration.GetSingleValue<int?>("SELECT FinancialSystemType FROM dbo.FinancialSystemServicePoint");
            if (finacialSystemType.HasValue && finacialSystemType.Value == 2)//آیا سیستم مالی همکاران سیستم هست؟
            {
                FinancialSystemIsHamkaran = true;
            }
        }

        /// <summary>Enables the table tracking. </summary>
        /// <param name="tableName">table name in database. </param>
        public void EnableTableTracking(string tableName)
        {
            string scriptDBTracking = string.Format("SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID('{0}')", _databaseName);
            DataTable trackingDBData = _scriptExe.GetDataTable(scriptDBTracking);

            if (trackingDBData.Rows.Count == 0)
            {
                try
                {
                    string script = string.Format("ALTER DATABASE {0} SET CHANGE_TRACKING = ON (CHANGE_RETENTION = 5 DAYS, AUTO_CLEANUP = ON)", _databaseName);
                    _scriptExe.ScriptRun(script);
                }
                catch (Exception ex)
                {
                    Logger.ExceptionLog(ex);
                }
            }

            string scriptTableTracking = string.Format("SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID('{0}')", tableName);
            DataTable trackingTableData = _scriptExe.GetDataTable(scriptTableTracking);

            if (trackingTableData.Rows.Count == 0)
            {
                try
                {
                    string scriptEnableTableTracking = string.Format("ALTER TABLE {0} ENABLE CHANGE_TRACKING WITH(TRACK_COLUMNS_UPDATED = OFF)", tableName);
                    _scriptExe.ScriptRun(scriptEnableTableTracking);
                }
                catch (Exception ex)
                {
                    Logger.ExceptionLog(ex);
                }
            }
        }

        /// <summary>Disables the table tracking. </summary>
        /// <param name="tableName">Table name in database. </param>
        /// <returns>   True if it succeeds, false if it fails.(Always returns true)</returns>

        public bool DisableTableTracking(string tableName)
        {
            string scriptDBTracking = string.Format("SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID('{0}')", _databaseName);
            DataTable trackingDBData = _scriptExe.GetDataTable(scriptDBTracking);

            if (trackingDBData.Rows.Count == 0)
                return true;


            string scriptTableTracking = string.Format("SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID('{0}')", tableName);
            DataTable trackingTableData = _scriptExe.GetDataTable(scriptTableTracking);

            if (trackingTableData.Rows.Count == 0)
                return true;

            string scriptEnableTableTracking = string.Format("ALTER TABLE {0} DISABLE CHANGE_TRACKING", tableName);
            _scriptExe.ScriptRun(scriptEnableTableTracking);

            return true;

        }

        /// <summary>Current tracking version. </summary>
        /// <returns> A long.</returns>
        public long CurrentTrackingVersion()
        {
            var version = _scriptExe.GetSingleValue<long>("SELECT NewTableVersion = CHANGE_TRACKING_CURRENT_VERSION()");

            return version;
        }

        /// <summary>   Gets change table. </summary>
        /// <remarks>   S Sepahvand, 9/27/2020. </remarks>
        /// <param name="tableName">    table name in database. </param>
        /// <param name="afterVersion"> The after version. </param>
        /// <returns>   The change table. </returns>
        public DataTable GetChangeTable(string tableName, long afterVersion)
        {
            if (FinancialSystemIsHamkaran)
            {
                string scriptTracking = string.Format("select * from  CHANGETABLE(CHANGES {0}.{1},{2}) AS ChTbl", _databaseName, tableName, afterVersion);
                var changeTable = _scriptExePgIntegration.GetDataTable(scriptTracking);
                return changeTable;
            }
            else
            {
                string scriptTracking = string.Format("select * from  CHANGETABLE(CHANGES {0},{1}) AS ChTbl", tableName, afterVersion);
                var changeTable = _scriptExe.GetDataTable(scriptTracking);
                return changeTable;
            }
        }

        /// <summary>Gets table name and returns current tracking version. </summary>
        /// <param name="tableName">    table name in database. </param>
        /// <returns>   A long. </returns>
        public long CurrentTrackingVersion(string tableName)
        {
            if (FinancialSystemIsHamkaran)
            {
                string scriptTracking = string.Format("select Max(SYS_CHANGE_VERSION) from  CHANGETABLE(CHANGES {0}.{1},{2}) AS ChTbl", _databaseName, tableName, 0);
                var lastTrack = _scriptExePgIntegration.GetSingleValue<long>(scriptTracking);
                return lastTrack;
            }
            else
            {
                string scriptTracking = string.Format("select Max(SYS_CHANGE_VERSION) from  CHANGETABLE(CHANGES {0},{1}) AS ChTbl", tableName, 0);
                var lastTrack = _scriptExe.GetSingleValue<long>(scriptTracking);
                return lastTrack;
            }
        }

        /// <summary>   Gets change table action type. </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="changeTableRowItem">   The change table row item. </param>
        /// <returns>   The change table action type. </returns>
        public ActionType GetChangeTableActionType(DataRow changeTableRowItem)
        {
            string type = changeTableRowItem.Field<string>("SYS_CHANGE_OPERATION");

            if (type == "I")
                return ActionType.Insert;
            if (type == "U")
                return ActionType.Update;
            if (type == "D")
                return ActionType.Delete;

            throw new Exception(string.Format("Unknow CHANGE_OPERATION type. [{0}]", type));
        }
    }
}