using System;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>ContactAddress</c> class</para>
    /// <para>Contains Contact information like adress, country and etc.</para>
    /// </summary>
    [DataContract]
    public class ContactAddress
    {
        /// <summary>   Gets or sets the identifier of the crm. </summary>
        /// <value> The identifier of the crm. </value>
        [DataMember]
        public Guid CrmId { get; set; }

        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        [DataMember]
        public string Key { get; set; }

        /// <summary>   Gets or sets the address of contact. </summary>
        /// <value> The address. </value>
        [DataMember]
        public string Address { get; set; }

        /// <summary>   Gets or sets the city of contact. </summary>
        /// <value> The city. </value>
        [DataMember]
        public string City { get; set; }

        /// <summary>   Gets or sets the country of contact. </summary>
        /// <value> The country. </value>
        [DataMember]
        public string Country { get; set; }

        /// <summary>   Gets or sets the state of contact. </summary>
        /// <value> The state. </value>
        [DataMember]
        public string State { get; set; }

        /// <summary>   Gets or sets the zip code of contact. </summary>
        /// <value> The zip code. </value>
        [DataMember]
        public string ZipCode { get; set; }

        /// <summary>   Gets or sets a value indicating whether this  is default.
        ///             adds defualt values to contact.</summary>
        /// <value> True if this  is default, false if not. </value>
        [DataMember]
        public bool IsDefault { get; set; }
    }
}
