using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VaultApp.Model
{
    internal class DataCredit
    {
        public string Creditname { get; set; }
        public string Creditamount { get; set; }
        public string Creditdesc { get; set; }
        public string Creditstatus { get; set; }

        public DataCredit(string creditname, string creditamount, string creditdesc, string creditstatus)
        {
            Creditname = creditname;
            Creditamount = creditamount;
            Creditdesc = creditdesc;
            Creditstatus = creditstatus;
        }
    }
}
