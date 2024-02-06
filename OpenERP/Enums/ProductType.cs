using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main<c>ProductType</c> enum.</para>
    /// <para>Determines the type of services it provides to the customer</para>
    /// </summary>
    [DataContract]
    [Flags]
    public enum ProductType
    {
        /// <summary>
        /// Product, like pen,laptop and etc.
        /// </summary>
        [EnumMember]
        [Description("کالا")]
        Product = 1,

        /// <summary>
        /// Service, like cleaning the house, transportation and etc.
        /// </summary>
        [EnumMember]
        [Description("خدمات")]
        Service = 2
    }
}
