using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultApp.Model
{
    internal class DataAccount
    {

        public string Accountname {  get; set; }
        public string Accountuser {  get; set; }
        public string Accountpass { get; set; }
        public string Accountmobile { get; set; }
        public string Accountemail { get; set; }
        public string Accountlink { get; set; }
        public string Accountcategory { get; set; }
        public string Accountsecurity { get; set; }
        public string Accountstatus { get; set; }
    
        public DataAccount(string accountname, string accountuser, string accountpass, string accountmobile, string accountemail, 
                         string accountlink, string accountcategory, string accountsecurity, string accountstatus)
        {
            Accountname = accountname;
            Accountuser = accountuser;
            Accountpass = accountpass;
            Accountmobile = accountmobile;
            Accountemail = accountemail;
            Accountlink = accountlink;
            Accountcategory = accountcategory;
            Accountsecurity = accountsecurity;
            Accountstatus = accountstatus;

        }

        
      

    }
}
