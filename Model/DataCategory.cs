using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultApp.Model
{
    internal class DataCategory
    {

        public string Categoryname { get; set; }
   
        public DataCategory(string categoryName)
        {
            Categoryname = categoryName;
        }
    }
}
