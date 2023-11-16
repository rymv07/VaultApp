using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.Model;

namespace VaultApp.View
{
    public partial class CreditsForm : Form
    {

        private readonly MainForm _parent;

        string creditid, creditname, creditamount, creditdesc, creditstatus;

        public string Creditid { get => creditid; set => creditid = value; }
        public string Creditname { get => creditname; set => creditname = value; }
        public string Creditamount { get => creditamount; set => creditamount = value; }
        public string Creditdesc { get => creditdesc; set => creditdesc = value; }
        public string Creditstatus { get => creditstatus; set => creditstatus = value; }

        string dataAdd = "New";
        string dataUpdate = "Update";

        public CreditsForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

       
        public void ClearCinfo()
        {
            txtcname.Text = txtcamount.Text = txtcdesc.Text = string.Empty;
        }

        public void AddCreditInfo()
        {
            this.Text = "Credits/Add";
            lblHeader.Text = dataAdd;
            cbocstatus.SelectedIndex = 0;

            

        }

        public void UpdateCreditInfo()
        {
            this.Text = "Credits/Update";
            lblHeader.Text = dataUpdate;
            lblcref.Visible = true;
            txtcref.Visible = true;
            txtcname.Text = Creditname;
            txtcamount.Text = Creditamount;
            txtcdesc.Text = Creditdesc;
            cbocstatus.SelectedItem = Creditstatus;
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtcname.Text.Length < 3)
            {
                MessageBox.Show("Name should not be Empty.");
                return;
            }

           
            if (txtcamount.Text.Length <= 0)
            {
                MessageBox.Show("Should Input Valid amount.");
                return;
            }

          
            if (lblHeader.Text == dataAdd)
            {
                DataCredit dc = new DataCredit(txtcname.Text.Trim(), txtcamount.Text.Trim(), txtcdesc.Text.Trim(),cbocstatus.Text.Trim());
                DatabaseModel.AddCreditData(dc);
                ClearCinfo();
            }
            if (lblHeader.Text == dataUpdate)
            {
                DataCredit dc = new DataCredit(txtcname.Text.Trim(), txtcamount.Text.Trim(), txtcdesc.Text.Trim(), cbocstatus.Text.Trim());
                DatabaseModel.UpdateCreditData(dc, Creditid);
                ClearCinfo();
            }
            _parent.DisplayInfo();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCinfo();
        }


    }
}
