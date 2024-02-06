using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>InvoiceDetail</c> class.</para>
    /// <para>In this class, invoice details such as count, price, etc. are defined.</para>
    /// </summary>
    [DataContract]
    public class InvoiceDetail
    {
        /// <summary>
        /// Initial price of the product without VAT and taxes
        /// </summary>
        /// <value>Gets or sets BaseUnitPrice.</value>
        [DataMember]
        public decimal BaseUnitPrice { get; set; }

        /// <summary>
        /// Count of product
        /// </summary>
        /// <value>Gets or sets Count. </value>
        [DataMember]
        public decimal Count { get; set; }

        /// <summary>
        /// The final price of the product
        /// </summary>
        /// <value>Gets or sets FinalUnitPrice.</value>
        [DataMember]
        public decimal FinalUnitPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets ProductCode.</value>
        [DataMember]
        public string ProductCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets ProductName.</value>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets ReturnedCount.</value>
        [DataMember]
        public decimal ReturnedCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets Serial.</value>
        [DataMember]
        public string Serial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets TotalDiscount.</value>
        [DataMember]
        public decimal TotalDiscount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets TotalTax.</value>
        [DataMember]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value></value>
        [DataMember]
        public decimal TotalToll { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value></value>
        [DataMember]
        public decimal TotalOtherAddition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets TotalUnitPrice.</value>
        [DataMember]
        public decimal TotalUnitPrice { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets Product.</value>
        [DataMember]
        public ProductBundle Product { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance /.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance ; otherwise, <see langword="false" />.</value>
        [DataMember]
        public bool IsService { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets InventoryCode.</value>
        [DataMember]
        public string InventoryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets DetailDescription.</value>
        [DataMember]
        public string DetailDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>Gets or sets ProductKey.</value>
        [DataMember]
        public string ProductKey { get; set; }
    }
}
