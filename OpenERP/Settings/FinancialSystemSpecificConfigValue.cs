using System.Diagnostics;

namespace AbrPlus.Integration.OpenERP.Settings
{
    /// <summary>
    /// <para>The main <c>FinancialSystemSpecificConfigValue</c> class.</para>
    /// <para> A financial system specific configuration value.</para>
    /// </summary>
    [DebuggerDisplay("Key={Key}, Value={Value}")]
    public class FinancialSystemSpecificConfigValue
    {
        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        public string Key { get; set; }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; set; }
    }
}