using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>FinancialySystemSetting</c> class</para>
    /// <para>  A financial system settings.</para>
    /// </summary>
    [DataContract]
    public class FinancialSystemSettings
    {
        ///<summary>   Default constructor. </summary>
        public FinancialSystemSettings()
        {
            CompanySettings = new List<CompanySettings>();
        }

        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        [DataMember]
        public int Id { get; set; }

        /// <summary>   Gets or sets the title. </summary>
        /// <value> The title. </value>
        [DataMember]
        public string Title { get; set; }

        /// <summary>   Gets or sets the service address. </summary>
        /// <value> The service address. </value>
        [DataMember]
        public string ServiceAddress { get; set; }

        /// <summary>   Gets or sets the service username. </summary>
        /// <value> The service username. </value>
        [DataMember]
        public string ServiceUsername { get; set; }

        /// <summary>   Gets or sets the service password. </summary>
        /// <value> The service password. </value>
        [DataMember]
        public string ServicePassword { get; set; }

        /// <summary>   Gets or sets the database address. </summary>
        /// <value> The database address. </value>
        [DataMember]
        public string DatabaseAddress { get; set; }

        /// <summary>   Gets or sets the name of the database. </summary>
        /// <value> The name of the database. </value>
        [DataMember]
        public string DatabaseName { get; set; }

        /// <summary>   Gets or sets the database username. </summary>
        /// <value> The database username. </value>
        [DataMember]
        public string DatabaseUsername { get; set; }

        /// <summary>   Gets or sets the database password. </summary>
        /// <value> The database password. </value>
        [DataMember]
        public string DatabasePassword { get; set; }

        /// <summary>   Gets or sets the name of the financial system type. </summary>
        /// <value> The name of the financial system type. </value>
        [DataMember]
        public string FinancialSystemTypeName { get; set; }

        /// <summary>   Gets or sets the zero-based index of the financial system type. </summary>
        /// <value> The financial system type index. </value>
        [DataMember]
        public int FinancialSystemTypeIndex { get; set; }

        /// <summary>   Gets or sets a value indicating whether this  use windows credential. </summary>
        /// <value> True if use windows credential, false if not. </value>
        [DataMember]
        public bool UseWindowsCredential { get; set; }

        /// <summary>   Gets or sets the company settings. </summary>
        /// <value> The company settings. </value>
        [DataMember]
        public List<CompanySettings> CompanySettings { get; set; }
    }
}
