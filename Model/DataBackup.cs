using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaultApp.Model
{
    internal class DataBackup
    {
        public string Backupacname { get; set; }
        public string Backupcode { get; set; }
        public string Backupcodetype { get; set; }
        public string Backupcodestatus { get; set; }

        public DataBackup(string backupacname, string backupcode, string backupcodetype, string backupcodestatus)
        {
            Backupacname = backupacname;
            Backupcode = backupcode;
            Backupcodetype = backupcodetype;
            Backupcodestatus = backupcodestatus;
        }
    }
}
