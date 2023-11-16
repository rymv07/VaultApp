using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.Model;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace VaultApp.View
{
    public partial class PersonalForm : Form
    {

        private readonly MainForm _parent;

        string pid, paccountname, paccountdetails, pmobile, pemail;

        public string Pid { get => pid; set => pid = value; }
        public string Paccountname { get => paccountname; set => paccountname = value; }
        public string Paccountdetails { get => paccountdetails; set => paccountdetails = value; }
        public string Pmobile { get => pmobile; set => pmobile = value; }
        public string Pemail { get => pemail; set => pemail = value; }


        string dataAdd = "New";
        string dataUpdate = "Update";


        public PersonalForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;

        }

        public void AddPersonalInfo()
        {
            this.Text = "Add New";
            lblpheader.Text = dataAdd;
            

        }

        public void UpdatePersonalInfo()
        {
            this.Text = "Update";
            lblpheader.Text = dataUpdate;
            lblpref.Visible = true;
            txtpref.Visible = true;
            txtpref.Text = Pid;
            txtpacname.Text = Paccountname;
            txtpacdet.Text = Paccountdetails;
            txtpmobile.Text = Pmobile;
            txtpemail.Text = Pemail;
            

        }

        public void ClearPinfo()
        {
            txtpacname.Text = txtpacdet.Text = txtpmobile.Text = txtpemail.Text = string.Empty;
        }


        private void btnpSave_Click(object sender, EventArgs e)
        {
            if (txtpacname.Text.Length < 2)
            {
                MessageBox.Show("Account Name should not be Empty.");
                return;
            }

            if (lblpheader.Text == dataAdd)
            {
                DataPersonal dp = new DataPersonal(txtpacname.Text.Trim(),txtpacdet.Text.Trim(),txtpmobile.Text.Trim(),txtpemail.Text.Trim());
                DatabaseModel.AddPersonalData(dp);
                ClearPinfo();
            }
            if (lblpheader.Text == dataUpdate)
            {
                DataPersonal dp = new DataPersonal(txtpacname.Text.Trim(), txtpacdet.Text.Trim(), txtpmobile.Text.Trim(), txtpemail.Text.Trim());
                DatabaseModel.UpdatePersonalData(dp, Pid);
                ClearPinfo();
            }
            _parent.DisplayInfo();
        }

        private void btnpClear_Click(object sender, EventArgs e)
        {
            ClearPinfo();
        }
    }
}
