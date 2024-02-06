using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>SyncItemType</c> enum.</para>
    /// <para>Values that represent Synchronize item types.
    /// Specifies the type of item to sync.</para>
    /// </summary>

    public enum SyncItemType : int
    {

        /// <summary>
        /// Customer type.
        /// </summary>
        [Description("مشتری")]
        Customer = 1,

        /// <summary>
        /// Customer type.
        /// </summary>
        [Description("کالا")]
        Product = 2,

        /// <summary>
        /// Purchase Invoice type.
        /// </summary>
        [Description("فاکتور خرید")]
        PurchaseInvoice = 3,

        /// <summary>
        /// Sale Invoice type.
        /// </summary>
        [Description("فاکتور فروش")]
        SaleInvoice = 4,

        /// <summary>
        /// Customer type.
        /// </summary>
        [Description("فاکتور برگشت از خرید")]
        RetPurchaseInvoice = 5,

        /// <summary>
        /// Return Sale Invoice type.
        /// </summary>
        [Description("فاکتور برگشت از فروش")]
        RetSaleInvoice = 6,

        /// <summary>
        /// Payment type.
        /// </summary>
        [Description("پرداخت")]
        Payment = 7,

        /// <summary>
        /// Receipt type.
        /// </summary>
        [Description("دریافت")]
        Receipt = 8,

        /// <summary>
        /// Sale Quote type.
        /// </summary>
        [Description("پیش فاکتور فروش")]
        SaleQuote = 9,

        /// <summary>
        /// Price List type.
        /// </summary>
        [Description("لیست قیمت")]
        PriceList = 10,

        /// <summary>
        /// Voucher type.
        /// </summary>
        [Description("سند حسابداری")]
        Voucher = 11,

        /// <summary>
        /// Contract type.
        /// </summary>
        [Description("قرارداد")]
        Contract = 12,
    }
}
