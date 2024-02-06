using System;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// The main <c>VoucherBundle</c> class.
    /// Determines all properties of Voucher bundel.
    /// </summary>
    /// <see cref="BundleBase"/>
    [DataContract]
    public class VoucherBundle : BundleBase
    {
        /// <summary>
        /// Determines the amount of identity debt to the system
        /// </summary>
        /// <value>Gets and value of Debit</value>
        [DataMember]
        public decimal Debit { get; set; }

        /// <summary>
        /// Determines the amount of identity credit to the system
        /// </summary>
        /// <value>Gets and sets value of Credit</value>
        [DataMember]
        public decimal Credit { get; set; }

        /// <summary>
        /// Maintains the date of payment or settlement day
        /// </summary>
        /// <value>Gets and sets value of Date</value>
        /// <see cref="DateTime"/>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Determines the amount of Number.
        /// </summary>
        /// <value>Gets and sets value of Number</value>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Maintains voucher item descripton.
        /// </summary>
        /// <value>Gets and sets value of Subject</value>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Determines the amount of Description.
        /// </summary>
        /// <value>Gets and sets value of Description</value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Determines the amount of VoucherId.
        /// </summary>
        /// <value>Gets and sets value of VoucherId</value>
        [DataMember]
        public string VoucherId { get; set; }

        /// <summary>
        /// Determines the amount of VoucherType.
        /// </summary>
        /// <value>Gets and sets value of VoucherType</value>
        [DataMember]
        public string VoucherType { get; set; }

        /// <summary>
        /// Determines the amount of VoucherState.
        /// </summary>
        /// <value>Gets and sets value of VoucherState</value>
        [DataMember]
        public string VoucherState { get; set; }

        /// <summary>
        /// Determines the amount of CustomerCode.
        /// </summary>
        /// <value>Gets and sets value of CustomerCode</value>
        [DataMember]
        public string CustomerCode { get; set; }
    }
}
