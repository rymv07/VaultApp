using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.Model;
using static System.Net.Mime.MediaTypeNames;

namespace VaultApp.View
{
    public partial class BackupForm : Form
    {
        private readonly MainForm _parent;

        string backupid, backupacname, backupcode, backupcodetype, backupcodestatus;

        public string Backupid { get => backupid; set => backupid = value; }
        public string Backupacname { get => backupacname; set => backupacname = value; }
        public string Backupcode { get => backupcode; set => backupcode = value; }
        public string Backupcodetype { get => backupcodetype; set => backupcodetype = value; }
        public string Backupcodestatus { get => backupcodestatus; set => backupcodestatus = value; }


        string dataAdd = "New";
        string dataUpdate = "Update";

        

        public BackupForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;

        }


        public void AddBackInfo()
        {
            this.Text = "Backup Code/Add";
            lblheader.Text = dataAdd;
            cbocodetype.SelectedIndex = 0;
            cbocodestats.SelectedIndex = 0;
            
        }

        public void UpdateBackInfo()
        {
            this.Text = "Backup Code/Update";
            lblheader.Text = dataUpdate;
            lblid.Visible = true;
            txtid.Visible = true;
            txtid.Text = Backupid;
            cbocodetype.SelectedText = Backupcodetype;
            cbocodestats.SelectedText = Backupcodestatus;
            txtaccount.Text = Backupacname;
            txtcode.Text = Backupcode;
            
        }

     
        public void ClearBackinfo()
        {
           txtaccount.Text = txtcode.Text = string.Empty;
        }

        
        private void btnsavebu_Click(object sender, EventArgs e)
        {


            if (txtaccount.Text.Length < 1)
            {
                MessageBox.Show("Fill in Name of Account");
                return;
            }

            if (txtcode.Text.Length < 1)
            {
                MessageBox.Show("Fill in Code.");
                return;
            }
      
           
            if (lblheader.Text == dataAdd)
            {
                DataBackup dbu = new DataBackup(txtaccount.Text.Trim(),txtcode.Text.Trim(),cbocodetype.Text.Trim(),cbocodestats.Text.Trim());
                DatabaseModel.AddBackupData(dbu);
                ClearBackinfo();
            }
            if (lblheader.Text == dataUpdate)
            {
                DataBackup dbu = new DataBackup(txtaccount.Text.Trim(), txtcode.Text.Trim(), cbocodetype.Text.Trim(), cbocodestats.Text.Trim());
                DatabaseModel.UpdateBackupData(dbu, Backupid);
                ClearBackinfo();
            }
            _parent.DisplayInfo();
        }

        private void btnclearbu_Click(object sender, EventArgs e)
        {
            ClearBackinfo();
        }

    }
}
