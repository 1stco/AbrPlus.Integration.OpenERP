using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>ExtendedProperty</c> class</para>
    /// <para>An extended property</para>
    /// </summary>
    [DataContract]
    public class ExtendedProperty
    {
        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        [DataMember]
        public string Key { get; set; }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        [DataMember]
        public string Value { get; set; }

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>   Gets or sets a value indicating whether this  is extra data. </summary>
        /// <remarks>Is exta data can be like takhfif cart, takhfif sandoghdar and etc.</remarks>
        /// <value> True if this  is extra data, false if not. </value>
        [DataMember]
        public bool IsExtraData { get; set; }
    }
}
