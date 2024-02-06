using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbrPlus.Integration.OpenERP.Api.DataContracts
{
    [Serializable]
    public class SettingModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
