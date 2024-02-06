using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>SyncDirection</c> enum</para>
    /// Values that represent Synchronize directions.
    /// </summary>
    public enum SyncDirection : int
    {
        /// <summary>   An enum constant representing the import option. </summary>
        [Description("انتقال به پیام گستر")]
        Import = 1,

        /// <summary>   An enum constant representing the export option. </summary>
        [Description("انتقال به حسابداری")]
        Export = 2,
    }
}
