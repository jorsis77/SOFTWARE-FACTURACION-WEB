using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MULTI.Util
{
    public class TenantSettings
    {
        public Dictionary<string, TenantData> Sites { get; set; }
    }

    public class TenantData
    {
        public string connectionString { get; set; }
       // public string logo { get; set; }
       // public string name { get; set; }
        //public string Cod_Emp { get; set; }
    }
}
