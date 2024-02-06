using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>CompanySettings</c> class</para>
    /// <para>Contains all properties for company setting</para>
    /// </summary>
    [DataContract]
    public class CompanySettings
    {
        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        [DataMember]
        public int Id { get; set; }

        /// <summary>   Gets or sets the identifier of the financial system service point. </summary>
        /// <value> The identifier of the financial system service point. </value>
        [DataMember]
        public int FinancialSystemServicePointId { get; set; }

        [DataMember]
        /// <summary>
        /// A read only number between 100 to 999
        /// </summary>

        /// <summary>   Gets or sets the code. </summary>
        /// <value> The code. </value>

        public int? Code { get; set; }

        ///<summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        [DataMember]
        public string Name { get; set; }

        ///<summary>   Gets or sets the name of the database. </summary>
        /// <value> The name of the database. </value>
        [DataMember]
        public string DatabaseName { get; set; }

        /// <summary>   Gets or sets the connection string. </summary>
        /// <value> The connection string. </value>
        [DataMember]
        public string ConnectionString { get; set; }

        /// <summary>   Gets or sets the financial year. </summary>
        /// <value> The financial year. </value>
        [DataMember]
        public string FinancialYear { get; set; }

        /// <summary>   Gets or sets the identity category key. </summary>
        /// <value> The identity category key. </value>
        [DataMember]
        public string IdentityCategoryKey { get; set; }

        /// <summary>   Gets or sets the person type key. </summary>
        /// <value> The person type key. </value>
        [DataMember]
        public string PersonTypeKey { get; set; }

        // <summary>   Gets or sets the organization type key. </summary>
        /// <value> The organization type key. </value>
        [DataMember]
        public string OrganizationTypeKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize identity addresses.
        /// </summary>
        /// <value> True if synchronize identity addresses, false if not. </value>
        [DataMember]
        public bool SyncIdentityAddresses { get; set; }

        /// <summary>   Gets or sets a value indicating whether the synchronize products. </summary>
        /// <value> True if synchronize products, false if not. </value>
        [DataMember]
        public bool SyncProducts { get; set; }

        /// <summary>   Gets or sets a value indicating whether this  is default. </summary>
        /// <value> True if this  is default, false if not. </value>
        [DataMember]
        public bool IsDefault { get; set; }

        /// <summary>   Gets or sets a value indicating whether the synchronize sales quotes. </summary>
        /// <value> True if synchronize sales quotes, false if not. </value>
        [DataMember]
        public bool SyncSalesQuotes { get; set; }

        /// <summary>   Gets or sets the sales quote key. </summary>
        /// <value> The sales quote key. </value>
        [DataMember]
        public string SalesQuoteKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize purchase quotes.
        /// </summary>
        /// <value> True if synchronize purchase quotes, false if not. </value>
        [DataMember]
        public bool SyncPurchaseQuotes { get; set; }

        /// <summary>   Gets or sets the purchase quotes key. </summary>
        /// <value> The purchase quotes key. </value>
        [DataMember]
        public string PurchaseQuotesKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize sales invoices.
        /// </summary>
        /// <value> True if synchronize sales invoices, false if not. </value>
        [DataMember]
        public bool SyncSalesInvoices { get; set; }

        /// <summary>   Gets or sets a value indicating whether the sales invoices key. </summary>
        /// <value> True if sales invoices key, false if not. </value>
        [DataMember]
        public bool SalesInvoicesKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize purchase invoices.
        /// </summary>
        /// <value> True if synchronize purchase invoices, false if not. </value>
        [DataMember]
        public bool SyncPurchaseInvoices { get; set; }

        /// <summary>   Gets or sets a value indicating whether the purchase invoices key. </summary>
        /// <value> True if purchase invoices key, false if not. </value>
        [DataMember]
        public bool PurchaseInvoicesKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize return sales invoices.
        /// </summary>
        /// <value> True if synchronize return sales invoices, false if not. </value>
        [DataMember]
        public bool SyncReturnSalesInvoices { get; set; }

        /// <summary>   Gets or sets a value indicating whether the return sales invoices key. </summary>
        /// <value> True if return sales invoices key, false if not. </value>
        [DataMember]
        public bool ReturnSalesInvoicesKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize return purchase invoices.
        /// </summary>
        /// <value> True if synchronize return purchase invoices, false if not. </value>
        [DataMember]
        public bool SyncReturnPurchaseInvoices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the return purchase invoices key.
        /// </summary>
        /// <value> True if return purchase invoices key, false if not. </value>
        [DataMember]
        public bool ReturnPurchaseInvoicesKey { get; set; }

        /// <summary>   Gets or sets a value indicating whether the synchronize receipts. </summary>
        /// <value> True if synchronize receipts, false if not. </value>
        [DataMember]
        public bool SyncReceipts { get; set; }

        /// <summary>   Gets or sets a value indicating whether the receipts key. </summary>
        /// <value> True if receipts key, false if not. </value>
        [DataMember]
        public bool ReceiptsKey { get; set; }

        /// <summary>   Gets or sets a value indicating whether the synchronize payments. </summary>
        /// <value> True if synchronize payments, false if not. </value>
        [DataMember]
        public bool SyncPayments { get; set; }

        /// <summary>   Gets or sets a value indicating whether the payments key. </summary>
        /// <value> True if payments key, false if not. </value>
        [DataMember]
        public bool PaymentsKey { get; set; }

        /// <summary>   Gets or sets a value indicating whether the synchronize price lists. </summary>
        /// <value> True if synchronize price lists, false if not. </value>
        [DataMember]
        public bool SyncPriceLists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the synchronize accounting vouchers.
        /// </summary>
        /// <value> True if synchronize accounting vouchers, false if not. </value>
        [DataMember]
        public bool SyncAccountingVouchers { get; set; }

        /// <summary>   Gets or sets a value indicating whether the accounting vouchers key. </summary>
        /// <value> True if accounting vouchers key, false if not. </value>
        [DataMember]
        public bool AccountingVouchersKey { get; set; }

        /// <summary>   Gets or sets a value indicating whether the ignore errors. </summary>
        /// <value> True if ignore errors, false if not. </value>
        [DataMember]
        public bool IgnoreErrors { get; set; }

        /// <summary>   Gets or sets a value indicating whether the debug mode. </summary>
        /// <value> True if debug mode, false if not. </value>
        [DataMember]
        public bool DebugMode { get; set; }

        /// <summary>   Gets or sets the name of the product group. </summary>
        /// <value> The name of the product group. </value>
        [DataMember]
        public string ProductGroupName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the look only in product group.
        /// </summary>
        /// <value> True if look only in product group, false if not. </value>
        [DataMember]
        public bool LookOnlyInProductGroup { get; set; }
    }
}
