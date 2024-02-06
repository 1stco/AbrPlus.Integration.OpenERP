using System;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    /// <summary>
    /// The main <c>VoucherBundle</c> class.
    /// Determines all properties of Contract bundel.
    /// </summary>
    /// <see cref="BundleBase"/>
    [DataContract]
    public class ContractBundle : BundleBase
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Creator { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public decimal FinalValue { get; set; }

        [DataMember]
        public string CrmObjectTypeCode { get; set; }

        [DataMember]
        public string CustomerNo { get; set; }

        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
