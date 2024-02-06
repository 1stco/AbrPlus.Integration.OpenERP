using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// Determines the user identity
    /// </summary>
    [DataContract]
    [Flags]
    public enum IdentityType
    {
        /// <summary>
        /// Real identity
        /// </summary>
        [EnumMember]
        [Description("حقیقی")]
        Person = 1,

        /// <summary>
        /// Organization identity
        /// </summary>
        [EnumMember]
        [Description("حقوقی")]
        Corporate = 2
    }
}
