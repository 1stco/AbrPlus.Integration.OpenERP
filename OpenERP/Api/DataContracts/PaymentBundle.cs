using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{

    /// <summary>
    /// <para>The main <c>PaymentBundle</c> class.</para>
    /// </summary>
    /// <remarks>Extends <c>BundleBase</c> class.</remarks>
    /// <see cref="BundleBase"/>
    [DataContract]
    public class PaymentBundle : BundleBase
    {
        /// <summary>
        /// Contains note detail or description
        /// </summary>
        /// <value>Gets or sets value of Subject.</value>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Final value of product.
        /// </summary>
        /// <value>Gets or sets value of FinalValue.</value>
        [DataMember]
        public decimal FinalValue { get; set; }

        /// <summary>
        /// Determines receipt number
        /// </summary>
        /// <value>Gets or sets value of Number.</value>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Determines branch code.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string BranchCode { get; set; }

        /// <summary>
        /// D
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string ChequeBank { get; set; }

        /// <summary>
        /// Bank check serial number
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string ChequeNo { get; set; }

        /// <summary>
        /// If the item is of the received type. Stores the value True.
        /// </summary>
        /// <value>Gets or sets value of IsReceipt.</value>
        [DataMember]
        public bool IsReceipt { get; set; }

        /// <summary>
        /// If the item is of the payed type. Stores the value True.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public bool? IsPayed { get; set; }

        /// <summary>
        /// Item's money account
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        [Description("مدیریت حساب مالی")]
        public string MoneyAccount { get; set; }

        /// <summary>
        /// Determines pay date.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public DateTime? PayDate { get; set; }

        /// <summary>
        /// Determines payment method type. like: In-person payment, deposit to a bank account and etc.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Determines payment type. like Cash, credit and etc.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string PaymentType { get; set; }

        /// <summary>
        /// Defines the card serial number to receive
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string ReceiptCardNo { get; set; }

        /// <summary>
        /// Payment refrence number.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string RefNo { get; set; }

        /// <summary>
        /// Date of settlement
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public DateTime? SettledDate { get; set; }

        /// <summary>
        /// Saves related invoices
        /// </summary>
        /// <value>Gets or sets value of .</value>
        /// <see cref="InvoiceBundle"/>
        [DataMember]
        public InvoiceBundle RelatedInvoice { get; set; }

        /// <summary>
        /// Billing Description
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets value of .</value>
        /// <see cref="IdentityBundle"/>
        [DataMember]
        public IdentityBundle Customer { get; set; }

        /// <summary>
        /// Indicates which customer this payment bundle belongs to
        /// </summary>
        /// <value>Gets or sets value of .</value>
        //not so sure
        [DataMember]
        public string SubPaymentId { get; set; }

        /// <summary>
        /// Creates a new type of payment called a sub-payment
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string SubPaymentType { get; set; }

        /// <summary>
        /// Determines the current status of the cheque. For example, whether it is returned or not.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string ChequeState { get; set; }

        /// <summary>
        /// Determines facial year refrence.
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public string FiscalYearId { get; set; }

    }
}
