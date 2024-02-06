using System.Collections.Generic;

namespace AbrPlus.Integration.OpenERP.Settings
{
    public class CompanyConfig
    {
        public CompanyConfig()
        {
            SpecificSettings = new List<FinancialSystemSpecificConfig>();
        }

        public int Id { get; set; }

        public string DatabaseName { get; set; }

        public string Name { get; set; }

        public int? Code { get; set; }

        public string ConnecitonString { get; set; }

        public bool SyncCustomers { get; set; }
        public bool SyncProducts { get; set; }
        public bool SyncSalesQuotes { get; set; }
        public bool SyncSalesInvoices { get; set; }
        public bool SyncReturnSalesInvoices { get; set; }
        public bool SyncPurchaseInvoices { get; set; }
        public bool SyncReturnPurchaseInvoices { get; set; }
        public bool SyncPayments { get; set; }
        public bool SyncReceipts { get; set; }
        public bool SyncPriceLists { get; set; }
        public bool SyncAccountingVouchers { get; set; }


        public List<FinancialSystemSpecificConfig> SpecificSettings { get; set; }
    }
}