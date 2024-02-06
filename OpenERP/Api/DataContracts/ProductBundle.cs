using AbrPlus.Integration.OpenERP.Enums;
using System;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// The main <c>ProductBundle</c> class.
    /// Contains properties for product bundle.
    /// </summary>
    /// <remarks>Extends <c>BundleBase</c> class</remarks>
    /// <see cref="BundleBase"/>
    [DataContract]
    public class ProductBundle : BundleBase
    {
        /// <summary>
        /// Determines title of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Title</value>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Determines code of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Code</value>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Determines type of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Type</value>
        /// <see cref="ProductType"/>
        [DataMember]
        public ProductType Type { get; set; }

        /// <summary>
        /// Determines commission type of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of CommisionType</value>
        /// <remarks></remarks>
        public string CommisionType { get; set; }

        /// <summary>
        /// Determines commission of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of ProductKey</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public int? Commission { get; set; }

        /// <summary>
        /// Determines group description of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Description</value>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Determines group name of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of GroupName</value>
        [DataMember]
        public string GroupName { get; set; }

        /// <summary>
        /// Determines Id of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Id</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public Guid? Id { get; set; }

        /// <summary>
        /// Determines inventory of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Inventory</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public bool? Inventory { get; set; }

        /// <summary>
        /// Determines this product bundle is service or commodity.
        /// </summary>
        /// <value>Gets or Sets value of IsService</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public bool? IsService { get; set; }

        /// <summary>
        /// Determines which country has produced this product bundle.
        /// </summary>
        /// <value>Gets or Sets value of MadeIn</value>
        [DataMember]
        public string MadeIn { get; set; }

        /// <summary>
        /// Determines name of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Name</value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Determines unit type of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of ProductUnitType</value>
        [DataMember]
        public string ProductUnitType { get; set; }

        /// <summary>
        /// Determines sellable of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Sellable</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public bool? Sellable { get; set; }

        /// <summary>
        /// Determines taxable of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Taxable</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public bool? Taxable { get; set; }

        /// <summary>
        /// Determines information technology of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of TechInfo</value>
        [DataMember]
        public string TechInfo { get; set; }

        /// <summary>
        /// Determines unit buy price of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of UnitBuyPrice</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public decimal? UnitBuyPrice { get; set; }

        /// <summary>
        /// Determines unit price of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of UnitPrice</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Determines Brand of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of Brand</value>
        [DataMember]
        public string Brand { get; set; }

        /// <summary>
        /// Determines key of product bundle.
        /// </summary>
        /// <value>Gets or Sets value of ProductKey</value>
        /// <remarks>Identity primary key</remarks>
        [DataMember]
        public string ProductKey { get; set; }
    }
}
