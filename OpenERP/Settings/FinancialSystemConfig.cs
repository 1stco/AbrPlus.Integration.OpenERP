using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Settings
{
    /// <summary>
    /// <para>The main <c>FinancialSystemConfig</c> class.</para>
    /// <para>This class has fields for connecting to accounting systems</para>
    /// </summary>
    public class FinancialSystemConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialSystemConfig" /> class. 
        /// </summary>
        /// <see cref="CompanyConfig"/>
        public FinancialSystemConfig()
        {
            CompanyConfigs = new List<CompanyConfig>();
        }

        /// <summary>
        /// Contains company configs. can add, remove or find existing company config with company Id and
        /// </summary>
        /// <value>Gets or sets value of CompanyConfigs</value>
        /// <see cref="CompanyConfig"/>
        public List<CompanyConfig> CompanyConfigs { get; set; }

        /// <summary>
        /// config Id
        /// </summary>
        /// <value>Gets or sets value of Id </value>
        public int Id { get; set; }

        /// <summary>
        /// Config Type
        /// </summary>
        /// <value>Gets or sets value of Title</value>
        public string Title { get; set; }

        /// <summary>
        /// Database name.
        /// </summary>
        /// <value>Gets or sets value of DbAddress</value>
        public string DbAddress { get; set; }

        /// <summary>
        /// Username for connecting to database.
        /// </summary>
        /// <value>Gets or sets value of DbUserName</value>
        public string DbUserName { get; set; }

        /// <summary>
        /// Password for connecting to database.
        /// </summary>
        /// <value>Gets or sets value of DbPassword</value>
        public string DbPassword { get; set; }
    }
}
