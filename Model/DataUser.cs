using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VaultApp.Model
{
    internal class DataUser
    {
      
        public string Userpass { get; set; }

        public DataUser(string userpass)
        {
           
            Userpass = userpass;
        }
    }
}
