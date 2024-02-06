using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>ItemState</c> class.</para>
    /// <para>Determines the different modes of trying to store the item in the database</para>
    /// </summary>
    public enum ItemState : int
    {
        /// <summary>
        /// Item is in the queue to be added to the list
        /// </summary>
        [Description("در صف")]
        Queued = 1,

        /// <summary>
        /// Item could not be added to the list
        /// </summary>
        [Description("ناموفق")]
        Failed = 2,

        /// <summary>
        /// Item not added to list
        /// </summary>
        [Description("نادیده گرفته شده")]
        Ignored = 3,

        /// <summary>
        /// Item added to list.
        /// </summary>
        [Description("موفق")]
        Done = 4,

        /// <summary>
        /// Item was not added to the list automatically
        /// </summary>
        [Description("نادیده گرفته شده به صورت اتوماتیک")]
        AutoIgnored = 5
    }
}
