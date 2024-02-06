using System.Runtime.Serialization;
using System.ServiceModel;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>BundleBase</c> abstract class</para>
    /// <para>Determines base properties for <c>IdentityBundle</c> class.</par
    /// </summary>
    /// <remarks></remarks>
    [DataContract]
    public abstract class BundleBase
    {
        /// <summary>
        /// Determines Extended properties.
        /// </summary>
        /// <value>Gets and sets value of ExtendedProperties</value>
        /// <see cref="ExtendedProperty"/>
        [DataMember]
        public ExtendedProperty[] ExtendedProperties { get; set; }

        /// <summary>
        /// Maintains the fiscal year in which the check or invoice or etc is written
        /// </summary>
        /// <value>Gets and sets value of FiscalYear</value>
        [DataMember]
        public int FiscalYear { get; set; }

        /// <summary>
        /// Sync additional propery like total discount, total task and etc...
        /// </summary>
        /// <value>Gets or sets a value of SyncAdditionalProperty.</value>
        /// <see langword="true" /> if contains additional property, Returns true; otherwise, Returns false.<see langword="false" />.</value>
        [DataMember]
        public bool SyncAdditionalProperty { get; set; }

        /// <summary>
        /// Determines fix data sync.
        /// </summary>
        /// <value>Gets or sets value of FixDataSync</value>
        /// <see cref="DataContracts.FixDataSync"/>
        [DataMember]
        public FixDataSync FixDataSync { get; set; }

        /// <summary>
        /// Determines sync direction
        /// </summary>
        /// <value>Gets or sets value of SyncDirection</value>
        [DataMember]
        public int SyncDirection { get; set; }

        /// <summary>
        /// Determines SQL command query action type.
        /// </summary>
        /// <value>Gets or sets value of Action</value>
        [DataMember]
        public int Action { get; set; }

        /// <summary>
        /// Determines state of Items. like queue, ignored or etc.
        /// </summary>
        /// <value>Gets or sets value of State</value>
        [DataMember]
        public int State { get; set; }
    }
}
