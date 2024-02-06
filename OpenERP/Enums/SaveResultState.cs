using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>SaveResultState</c> enum.</para>
    /// <para>Determines the final status of item storage in the database/para>
    /// </summary>
    [DataContract]
    [Flags]
    public enum SaveResultState
    {
        /// <summary>
        /// Item saved successfully
        /// </summary>
        [EnumMember]
        [Description("موفق")]
        Successful = 1,

        /// <summary>
        /// Failed to save item
        /// </summary>
        /// <remarks></remarks>
        [EnumMember]
        [Description("ناموفق")]
        Failed = 2,

        /// <summary>
        /// Item was ignored for storage
        /// </summary>
        /// <remarks></remarks>
        [EnumMember]
        [Description("نادیده گرفته شد")]
        Ignored = 3,

        /// <summary>
        /// The item was automatically ignored for storage
        /// </summary>
        /// <remarks></remarks>
        [EnumMember]
        [Description("به صورت خودکار نادیدخ گرفته شد")]
        AutoIgnored = 4,

        /// <summary>
        /// The data type for storage is incorrect
        /// </summary>
        /// <remarks></remarks>
        [EnumMember]
        [Description("نوع داده اشتباه")]
        InvalidData = 5,

        /// <summary>
        /// Storage settings not specified
        /// </summary>
        [EnumMember]
        [Description("تنظیمات تعیین نشده است")]
        SettingNotSet = 6,

        /// <summary>
        /// The user does not have access to storage
        /// </summary>
        [EnumMember]
        [Description("درسترسی دارد")]
        NotPermited = 7,
    }
}
