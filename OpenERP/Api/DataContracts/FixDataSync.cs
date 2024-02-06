using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// <para>The main <c>FixDataSync</c> class.</para>
    /// <para></para>
    /// </summary>
    [DataContract]
    public class FixDataSync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixDataSync" /> class. 
        /// </summary>
        public FixDataSync()
        {
            Childs = new List<FixDataSync>();
        }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of CompanyId.</value>
        [DataMember]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of CrmObjectId.</value>
        /// <remarks>Nullable</remarks>
        [DataMember]
        public Guid? CrmObjectId { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of FinancialSystemKey.</value>
        [DataMember]
        public string FinancialSystemKey { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of FinacialEntityTypeName.</value>
        [DataMember]
        public string FinacialEntityTypeName { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of ItemType.</value>
        [DataMember]
        public int ItemType { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public int SyncDirection { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of .</value>
        [DataMember]
        public List<FixDataSync> Childs { get; set; }
    }
}
