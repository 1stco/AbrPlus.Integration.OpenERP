using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>PaymentType</c> enum.</para>
    /// <para>Specifies whether the transaction is of the received or paid type.</para>
    /// </summary>
    [DataContract]
    [Flags]
    public enum PaymentType
    {
        /// <summary>
        /// Payment type
        /// </summary>
        [EnumMember]
        [Description("پرداخت")]
        Payment = 1,

        /// <summary>
        /// Receipt type
        /// </summary>
        [EnumMember]
        [Description("دریافت")]
        Receipt = 2
    }
}
