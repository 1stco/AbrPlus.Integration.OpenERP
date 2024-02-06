using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>PhoneType</c> enum.</para>
    /// <para>Specifies phone number types</para>
    /// </summary>
    [DataContract]
    [Flags]
    public enum PhoneType
    {
        /// <summary>
        /// Mobile, like 09120000000
        /// </summary>
        [EnumMember]
        [Description("تلفن همراه")]
        Mobile = 1,

        /// <summary>
        /// land line, like 300033
        /// </summary>
        [EnumMember]
        [Description("لندلاین")]
        LandLine = 2,

        /// <summary>
        /// fax, like 2100000000
        /// </summary>
        [EnumMember]
        [Description("فکس")]
        Fax = 3,

        /// <summary>
        /// telefax
        /// </summary>
        /// <remarks></remarks>
        [EnumMember]
        [Description("دورنگار")]
        Telefax = 4
    }
}
