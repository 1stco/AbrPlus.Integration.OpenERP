using AbrPlus.Integration.OpenERP.Enums;
using System;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>ContactPhone</c> class</para>
    /// <para>Contains Contact phone information like type, number and etc.</para>
    /// </summary>

    [DataContract]
    public class ContactPhone
    {
        /// <summary>   Gets or sets the identifier of the crm. </summary>
        /// <value> The identifier of the crm. </value>
        [DataMember]
        public Guid CrmId { get; set; }

        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        [DataMember]
        public string Key { get; set; }

        /// <summary>   Gets or sets the number of contact.  </summary>
        /// <value> The number. </value>
        [DataMember]
        public string Number { get; set; }

        /// <summary>   Gets or sets the type of contact. </summary>
        /// <value> The type. </value>
        [DataMember]
        public PhoneType Type { get; set; }

        /// <summary>   Gets or sets a value indicating whether this  is default. </summary>
        /// <value> True if this  is default, false if not. </value>
        [DataMember]
        public bool IsDefault { get; set; }

        /// <summary>   Gets or sets the phone prefix./ </summary>
        /// <value> The phone prefix. </value>
        [DataMember]
        public string PhonePrefix { get; set; }

        /// <summary>   Gets or sets the continued number. </summary>
        /// <value> The continued number. </value>
        [DataMember]
        public string ContinuedNumber { get; set; }
    }
}
