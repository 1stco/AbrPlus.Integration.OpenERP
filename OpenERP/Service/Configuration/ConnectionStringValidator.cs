using System;
using System.Data.SqlClient;

namespace AbrPlus.Integration.OpenERP.Service.Configuration
{
    /// <summary>
    /// <para>The main <c>ConnectionStringValidator</c> class.</para>
    /// <para>Gets a SQL Server connection string and checks that it is valid or not.</para>
    /// </summary>
    /// <list type="bullet">
    /// <item>
    /// <term>Validate</term>
    /// <description>Connects to sql server.</description>
    /// </item>
    /// </list>
    public class ConnectionStringValidator : IConnectionStringValidator
    {
        /// <summary>
        /// Gets parameters and build a new <c>SqlConnectionStringBuilder</c> then send it to <c>Validate(string, out string)</c>.
        /// </summary>
        /// <remarks>
        /// If it can't connect to SQL server, Returns false with exeption message.
        /// </remarks>
        /// <param name="dataSource">Name of DataBase</param>
        /// <param name="integratedSecurity">Checks connection is Windows Authentication or not.</param>
        /// <param name="userId">Username</param>
        /// <param name="password">Password</param>
        /// <param name="message">If it could not connect to the SQL Server. Returns the exception message along with the false value.</param>
        /// <returns></returns>
        /// <see cref="Validate(string, out string)"/>
        public bool Validate(string dataSource, bool integratedSecurity, string userId, string password, out string message)
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = dataSource,
                IntegratedSecurity = integratedSecurity,
                UserID = userId,
                Password = password
            };

            return Validate(builder.ConnectionString, out message);
        }

        /// <summary>
        /// Gets SQL Server connection string and try to open connection.
        /// </summary>
        /// <remarks>
        /// If it can't connect to SQL server, Returns false with exeption message.
        /// </remarks>
        /// <param name="connectionString">SQL Connection string</param>
        /// <param name="message">If it could not connect to the SQL Server. Returns the exception message along with the false value.</param>
        /// <returns>If it can connect to SQL serverو Returns true.</returns>
        public bool Validate(string connectionString, out string message)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                message = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
