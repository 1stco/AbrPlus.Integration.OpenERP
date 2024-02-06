using System;
using System.Collections.Generic;
using System.Text;

namespace AbrPlus.Integration.OpenERP.Options
{
    public class AppOption
    {
        public string HttpPort { get; set; }
        public string HttpsPort { get; set; }
        public string StoragePath { get; set; }
        public bool UseLatestVersion { get; set; }
    }
}
