using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// The main <c>ActionType</c> enum.
    /// Determines the action of query on the SQL server.
    /// </summary>
    public enum ActionType : int
    {
        /// <summary>
        /// Insert Data to DataBase
        /// </summary>
        [Description("ایجاد")]
        Insert = 1,

        /// <summary>
        /// Update data in DataBase
        /// </summary>
        [Description("به روز رسانی")]
        Update = 2,

        /// <summary>
        /// Delete data from DataBase
        /// </summary>
        [Description("حذف")]
        Delete = 3
    }
}