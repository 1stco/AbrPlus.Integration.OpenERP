using System;
using System.Data;
using System.Data.SqlClient;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx.Services
{
    /// <summary>
    /// <para>The main <c>ScriptExecute</c> class.</para>
    /// <para>Execute SQL server queries.</para>
    /// </summary>
    public class ScriptExecute
    {
        string _connection;

        /// <summary>
        /// <para>Constructor</para>
        /// <para>Create connection string from <paramref name="connectionString"/>.</para>
        /// </summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public ScriptExecute(string connectionString)
        {
            _connection = connectionString;
        }
        //AppSetting _appSetting = new AppSetting();

        /// <summary>
        /// Sends <paramref name="sqlStatment"/> string to <c>ScriptRun(string, string)</c>
        /// </summary>
        /// <param name="sqlStatment"></param>
        /// <see cref="ScriptRun(string, string)"/>
        public void ScriptRun(string sqlStatment)
        {
            ScriptRun(sqlStatment, _connection);
        }

        /// <summary>
        /// Gets <paramref name="sqlStatment"/> and <paramref name="connection"/>. Then connects to 
        /// SQL server and Execute query.
        /// </summary>
        /// <param name="sqlStatment"></param>
        /// <param name="connection"></param>
        public void ScriptRun(string sqlStatment, string connection)
        {
            SqlConnection conn = null;
            try
            {
                //string sqlConnectionString = connectionString;
                string script = sqlStatment;

                //split the script on "GO" commands
                string[] splitter = new string[] { "\r\nGO\r\n" };
                string[] commandTexts = script.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                conn = new SqlConnection(connection);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                foreach (string commandText in commandTexts)
                {
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandTimeout = 1200; // 20 Minute
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                //Logger.ExceptionLog(e);
                throw e;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        /// <summary>
        /// Gets query and execute it. Returns
        /// </summary>
        /// <remarks>If SqlCommand.ExecuteScalar value will be null, Returns defualt value of <c>T</c></remarks>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="queryString">SQL Server Query</param>
        /// <returns>Convert RSqlCommand.ExecuteScala to T type amd returns it.</returns>
        public T GetSingleValue<T>(string queryString)
        {

            SqlConnection sqlConnection = new SqlConnection(_connection);
            SqlCommand cmd = new SqlCommand();
            object returnValue;

            cmd.CommandText = queryString;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            returnValue = cmd.ExecuteScalar();
            sqlConnection.Close();

            sqlConnection.Dispose();

            var t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (returnValue == null)
                {
                    return default;
                }

                t = Nullable.GetUnderlyingType(t);
            }
            if (returnValue == DBNull.Value || returnValue == null)
                return default;

            return (T)Convert.ChangeType(returnValue, t);
        }

        /// <summary>
        /// Gets query and execute it. Returns target Data table.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns>Data Table</returns>
        /// <see cref="DataTable"/>
        public DataTable GetDataTable(string queryString)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                adapter.Fill(table);

                adapter.Dispose();
                connection.Dispose();
            }

            return table;
        }

        /// <summary>
        /// Gets stored procedure name and execute it. 
        /// </summary>
        /// <param name="spName"></param>
        /// <returns>The number of elements in the SqlCommand.Parameters.Count as an Integer.</returns>
        public int SpParameterCount(string spName)
        {
            SqlConnection conn = new SqlConnection(_connection);
            SqlCommand cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlCommandBuilder.DeriveParameters(cmd);

            return cmd.Parameters.Count;

        }

        //public string SepidarEntityConnectionString(int type)
        //{
        //    string entityConnectionString;

        //    SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder(_appSetting.ConnectionString);

        //    switch (type)
        //    {
        //        case 0:
        //            conn.InitialCatalog = "PgIntegrationPlatform";
        //            entityConnectionString = "metadata=res://*/PgIntegrationPlatformEntities.csdl|res://*/PgIntegrationPlatformEntities.ssdl|res://*/PgIntegrationPlatformEntities.msl;provider=System.Data.SqlClient;provider connection string=\"" + conn.ConnectionString + ";App=EntityFramework\"";
        //            break;
        //        case 1:
        //            conn.InitialCatalog = "PgIntegrationPlatform";
        //            entityConnectionString = "metadata=res://*/SepidarIntegrationEntities.csdl|res://*/SepidarIntegrationEntities.ssdl|res://*/SepidarIntegrationEntities.msl;provider=System.Data.SqlClient;provider connection string=\"" + conn.ConnectionString + ";App=EntityFramework\"";
        //            break;
        //        case 2:
        //            entityConnectionString = "metadata=res://*/SepidarEntities.csdl|res://*/SepidarEntities.ssdl|res://*/SepidarEntities.msl;provider=System.Data.SqlClient;provider connection string=\"" + conn.ConnectionString + ";App=EntityFramework\"";
        //            break;
        //        default:
        //            throw new NotSupportedException();
        //    }
        //    return entityConnectionString;
        //}


        //public string TadbirEntityConnectionString(int type)
        //{
        //    string entityConnectionString;

        //    SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder(_appSetting.ConnectionString);

        //    switch (type)
        //    {
        //        case 0:
        //            conn.InitialCatalog = "PgIntegrationPlatform";
        //            entityConnectionString = "metadata=res://*/PgIntegrationPlatformEntities.csdl|res://*/PgIntegrationPlatformEntities.ssdl|res://*/PgIntegrationPlatformEntities.msl;provider=System.Data.SqlClient;provider connection string=\"" + conn.ConnectionString + ";App=EntityFramework\"";
        //            break;
        //        case 1:
        //            conn.InitialCatalog = "PgIntegrationPlatform";
        //            entityConnectionString = "metadata=res://*/TadbirIntegrationEntities.csdl|res://*/TadbirIntegrationEntities.ssdl|res://*/TadbirIntegrationEntities.msl;provider=System.Data.SqlClient;provider connection string=\"" + conn.ConnectionString + ";App=EntityFramework\"";
        //            break;
        //        case 2:
        //            entityConnectionString = "metadata=res://*/TadbirEntities.csdl|res://*/TadbirEntities.ssdl|res://*/TadbirEntities.msl;provider=System.Data.SqlClient;provider connection string=\"" + conn.ConnectionString + ";App=EntityFramework\"";
        //            break;
        //        default:
        //            throw new NotSupportedException();
        //    }
        //    return entityConnectionString;
        //}

    }
}
