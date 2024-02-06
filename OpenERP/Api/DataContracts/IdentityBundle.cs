using AbrPlus.Integration.OpenERP.Enums;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    [DataContract]
    public class IdentityBundle : BundleBase
    {
        public IdentityBundle()
        {
            Addresses = new ContactAddress[] { };
            Phones = new ContactPhone[] { };
        }

        [DataMember]
        public string Id { get; set; }

        //[DataMember]
        //public MainSource MainSource { get; set; }

        [DataMember]
        public IdentityType IdentityType { get; set; }

        [DataMember]
        public string BusinessType { get; set; }

        [DataMember]
        public decimal? Balance { get; set; }
        [DataMember]
        public ContactAddress[] Addresses { get; set; }

        [DataMember]
        public DateTime? CustomerDate { get; set; }

        [DataMember]
        public string CustomerNo { get; set; }

        [DataMember]
        public ContactPhone[] Phones { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string NationalCode { get; set; }

        [DataMember]
        public string EconomicCode { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public string OrganizationName { get; set; }

        [DataMember]
        public DateTime? RegisterBirthDate { get; set; }

        [DataMember]
        public string RegisterNo { get; set; }

        [DataMember]
        public string TradeMark { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public string CategoryPathToRoot { get; set; }

        [DataMember]
        public string SubSystemKey { get; set; }

        public bool RefIsFinancialSystem
        {
            get
            {
                if (ExtendedProperties != null)
                {
                    var ext = ExtendedProperties.FirstOrDefault(p => p.Key.ToLower() == "updatepermission");
                    if (ext != null)
                    {
                        var res = false;
                        return bool.TryParse(ext.Value, out res) && res;
                    }
                }
                return false;
            }
        }
    }
}
