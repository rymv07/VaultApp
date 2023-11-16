using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultApp.Model
{
    internal class DataPersonal
    {
        public string Paccountname {  get; set; }
        public string Paccountdetails { get; set; }
        public string Pmobile {  get; set; }
        public string Pemail { get; set; }

        public DataPersonal(string paccountname, string paccountdetails, string pmobile, string pemail)
        {
            Paccountname = paccountname;
            Paccountdetails = paccountdetails;
            Pmobile = pmobile;
            Pemail = pemail;
        }
    
    }
}
