using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{

    /// <summary>
    /// <para>The main <c>IdentityBalance</c> class.</para>
    /// <para>Defines information about the customer and the amount of his(her) debt or credit</para>
    /// </summary>
    /// <remarks></remarks>
    [DataContract]
    public class IdentityBalance
    {
        //[DataMember]
        //public string IdentityName { get; set; }

        /// <summary>
        /// Determines Customer number. uses for 
        /// </summary>
        /// <value>Gets or sets value of Gets or sets value of </value>
        /// <remarks></remarks>
        [DataMember]
        public string CustomerNumber { get; set; }


        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of Debit</value>
        /// <remarks></remarks>
        [DataMember]
        public decimal Debit { get; set; }


        /// <summary>
        /// Gets or sets .
        /// </summary>
        /// <value>Gets or sets value of Credit</value>
        /// <remarks></remarks>
        [DataMember]
        public decimal Credit { get; set; }


        /// <summary>
        ///  .
        /// </summary>
        /// <value>Gets or sets value of Remain</value>
        /// <remarks></remarks>
        [DataMember]
        public decimal Remain { get; set; }
    }
}
