using AbrPlus.Integration.OpenERP.Enums;
using System;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    [DataContract]
    public class InvoiceBundle : BundleBase
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public IdentityBundle Customer { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public decimal Discount { get; set; }

        [DataMember]
        public DateTime? ExpireDate { get; set; }

        [DataMember]
        public DateTime? InvoiceDate { get; set; }

        [DataMember]
        public InvoiceType InvoiceType { get; set; }

        [DataMember]
        public string PriceListName { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public decimal Toll { get; set; }

        [DataMember]
        public int TaxPercent { get; set; }

        [DataMember]
        public int TollPercent { get; set; }

        [DataMember]
        public decimal TotalValue { get; set; }

        [DataMember]
        public InvoiceDetail[] Details { get; set; }

        [DataMember]
        public PaymentBundle[] Payments { get; set; }

        [DataMember]
        public decimal FinalValue { get; set; }

        [DataMember]
        public string SubInvoiceId { get; set; }

        [DataMember]
        public string SubInvoiceType { get; set; }

        [DataMember]
        public decimal? AdditionalCosts { get; set; }

        [DataMember]
        public string CrmObjectTypeCode { get; set; }

        [DataMember]
        public string Creator { get; set; }

    }
}
