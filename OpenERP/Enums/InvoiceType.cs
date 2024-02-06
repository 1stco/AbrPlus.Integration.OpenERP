using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>InvoiceType</c> enum.</para>
    /// Determines the type of Invoices.
    /// </summary>
    [DataContract]
    [Flags]
    public enum InvoiceType
    {
        /// <summary>
        /// Quote invoice type
        /// </summary>
        [EnumMember]
        [Description("پیش فاکتور فروش")]
        Quote,

        /// <summary>
        /// Sales invoice type
        /// </summary>
        [EnumMember]
        [Description("فاکتور فروش")]
        Invoice,

        /// <summary>
        /// Return sale invoice type
        /// </summary>
        [EnumMember]
        [Description("فاکتور برگشت از فروش")]
        ReturnSaleInvoice,

        /// <summary>
        /// Purchase invoice type
        /// </summary>
        [EnumMember]
        [Description("فاکتور خرید")]
        PurchaseInvoice,

        /// <summary>
        /// Return purchase invoice type
        /// </summary>
        [EnumMember]
        [Description("فاکتور برگشت از خرید")]
        ReturnPurchaseInvoice
    }
}
