using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>MainSource</c> enum.</para>
    /// <para>Specifies whether the item is from a payam gostar or an accounting system</para>
    /// </summary>
    [DataContract]
    [Flags]
    public enum MainSource
    {
        /// <summary>
        /// accounting system
        /// </summary>
        [EnumMember]
        [Description("سیستم حسابداری")]
        TargetSystem = 1,

        /// <summary>
        /// Data comes from payam gostar
        /// </summary>
        [EnumMember]
        [Description("پیام گستر")]
        PayamGostar = 2
    }
}
