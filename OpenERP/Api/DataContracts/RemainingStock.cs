using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    [DataContract]
    public class RemainingStock
    {
        [DataMember]
        public string InventoryId { get; set; }

        [DataMember]
        public string InventoryCode { get; set; }

        [DataMember]
        public string InventoryName { get; set; }

        [DataMember]
        public decimal StockRemain { get; set; }

        [DataMember]
        public decimal FreezeRemain { get; set; }
    }
}
