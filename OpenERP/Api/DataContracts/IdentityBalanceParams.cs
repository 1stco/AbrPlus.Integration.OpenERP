using System;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    //[DataContract]
    //public class IdentityBalanceParams
    //{
    //    [DataMember]
    //    public List<string> CustomerNumbers { get; set; }

    //    [DataMember]
    //    public DateTime? FromDate { get; set; }

    //    [DataMember]
    //    public DateTime? ToDate { get; set; }

    //    [DataMember]
    //    public bool? IsDebit { get; set; }

    //    [DataMember]
    //    public bool LimitToHasRemain { get; set; }

    //    [DataMember]
    //    public decimal? FromBalanceAmount { get; set; }

    //    [DataMember]
    //    public decimal? ToBalanceAmount { get; set; }
    //}


    /// <summary>
    /// The main <c>IdentityBalanceParams</c> class.
    /// Contains all properties of Identity balance params.
    /// </summary>
    public class IdentityBalanceParams
    {
        /// <summary>
        /// Determines array of customer numbers of identity balance params.
        /// </summary>
        /// <value>Gets or sets value of CustomerNumbers</value>
        /// <remarks></remarks>
        public string[] CustomerNumbers { get; set; }

        /// <summary>
        /// Determines date of identity balance params.
        /// </summary>
        /// <value>Gets or sets value of ToDate</value>
        /// <remarks>Nullable</remarks>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Determines Balance result object of identity balance params.
        /// </summary>
        /// <value>Gets or sets value of BalanceResultType</value>
        /// <see cref="Models.BalanceResultType"/>
        public BalanceResultType BalanceResultType { get; set; }

        /// <summary>
        /// Determines from balance amount of identity balance params.
        /// </summary>
        /// <value>Gets or sets value of FromBalanceAmount</value>
        /// <remarks>Nullable</remarks>
        public decimal? FromBalanceAmount { get; set; }

        /// <summary>
        /// Determines to balance amount of identity balance params.
        /// </summary>
        /// <value>Gets or sets value of ToBalanceAmount</value>
        /// <remarks>Nullable</remarks>
        public decimal? ToBalanceAmount { get; set; }
    }
}
