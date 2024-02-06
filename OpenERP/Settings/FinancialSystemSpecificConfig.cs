using System.Collections.Generic;
using System.Diagnostics;

namespace AbrPlus.Integration.OpenERP.Settings
{
    /// <summary>
    /// <para>The main <c>FinancialSystemSpecificConfig</c> class.</para>
    /// <para>A financial system specific configuration.</para>
    /// </summary>
    [DebuggerDisplay("Key={Key}, Name={Name}, DisplayType={DisplayType}, Value={Value}, GroupName={GroupName}, Description={Description}")]
    public class FinancialSystemSpecificConfig
    {
        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        public string Key { get; set; }

        /// <summary>   Gets or sets the type of the display. display attribute hint. </summary>
        /// <value> The type of the display. </value>
        public string DisplayType { get; set; }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; set; }

        /// <summary>   Gets or sets the name of the group. </summary>
        /// <value> The name of the group. </value>
        public string GroupName { get; set; }

        /// <summary>   Gets or sets the description. </summary>
        /// <value> The description. </value>
        public string Description { get; set; }

        /// <summary>   Gets or sets the possible values. </summary>
        /// <value> The possible values. </value>
        /// <see cref="FinancialSystemSpecificConfigValue"/>
        public List<FinancialSystemSpecificConfigValue> PossibleValues { get; set; }
    }

    /// <summary>   A financial system specific configuration equality comaprer. </summary>
    /// <see cref="IEnumerable{T}"/>
    /// <seealso cref="FinancialSystemSpecificConfig"/>
    public class FinancialSystemSpecificConfigEqualityComaprer : IEqualityComparer<FinancialSystemSpecificConfig>
    {
        /// <summary>   Determines whether the specified objects are equal. </summary>
        /// <param name="x">    The first object of type <paramref name="x" /> to compare. </param>
        /// <param name="y">    The second object of type <paramref name="y" /> to compare. </param>
        /// <returns>
        /// <see langword="true" /> if the specified objects are equal; otherwise,
        /// <see langword="false" />.
        /// </returns>
        public bool Equals(FinancialSystemSpecificConfig x, FinancialSystemSpecificConfig y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            return x.Key == y.Key;
        }

        /// <summary>   Returns a hash code for the specified object. </summary>
        /// <param name="obj">  The <see cref="T:System.Object" /> for which a hash code is to be
        ///                     returned. </param>
        /// <returns>   A hash code for the specified object. </returns>
        public int GetHashCode(FinancialSystemSpecificConfig obj)
        {
            return (obj.Key ?? string.Empty).GetHashCode();
        }
    }
}