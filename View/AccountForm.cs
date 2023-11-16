using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VaultApp.Model;

namespace VaultApp.View
{
    public partial class AccountForm : Form
    {

        private readonly MainForm _parent;

        string refid, accountname, accountuser, accountpass, accountmobile, accountemail, accountlink, accountcategory, accountsecurity, accountstatus;

        public string Refid { get => refid; set => refid = value; }
        public string Accountname { get => accountname; set => accountname = value; }
        public string Accountuser { get => accountuser; set => accountuser = value; }
        public string Accountpass { get => accountpass; set => accountpass = value; }
        public string Accountmobile { get => accountmobile; set => accountmobile = value; }
        public string Accountemail { get => accountemail; set => accountemail = value; }
        public string Accountlink { get => accountlink; set => accountlink = value; }
        public string Accountcategory { get => accountcategory; set => accountcategory = value; }
        public string Accountsecurity { get => accountsecurity; set => accountsecurity = value; }
        public string Accountstatus { get => accountstatus; set => accountstatus = value; }
        //public string Accountvaulttype { get => accountvaulttype; set => accountvaulttype = value; }

        string dataAdd = "New";
        string dataUpdate = "Update";
       
        private void EntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (mvdbEntities db = new mvdbEntities())
                {
                    cboCategory.DataSource = db.vcdbs.ToList();
                    cboCategory.ValueMember = "categoryid";
                    cboCategory.DisplayMember = "categoryname";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            Cursor.Current = Cursors.WaitCursor;
            vcdb vobj = cboCategory.SelectedItem as vcdb;
            if (vobj != null)
            {
                vobj.categoryid.ToString();
                cboCategory.Text = vobj.categoryname;
            }
            Cursor.Current = Cursors.Default;

        }

      
        public AccountForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void ClearInfo()
        {
           txtAcName.Text = txtUserId.Text = txtPassword.Text = txtMobile.Text = txtEmail.Text = string.Empty;
        }

        public void AddInfo()
        {
            this.Text = "Account/Add";
            lblHeader.Text = dataAdd;

            btnClear.Enabled = true;
            btnClear.Visible = true;
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
            lblRef.Visible = false;
            txtRefId.Enabled = false;
            txtRefId.Visible = false;

            cboCategory.SelectedItem = 0;
            cboIsLink.SelectedIndex = 0;
            cboSecurity.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

        }

        public void UpdateInfo()
        {
            this.Text = "Account/Update";
            lblHeader.Text = dataUpdate;

            btnDelete.Enabled = true;
            btnDelete.Visible = true;
            btnClear.Enabled = false;
            btnClear.Visible = false;
            lblRef.Visible = true;
            txtRefId.Visible = true;

            txtRefId.Text = Refid;
            txtAcName.Text = Accountname;
            txtUserId.Text = Accountuser;
            txtPassword.Text = Accountpass;
            txtMobile.Text = Accountmobile;
            txtEmail.Text = Accountemail;
            cboCategory.SelectedItem = Accountcategory;
            cboIsLink.SelectedItem = Accountlink;
            cboSecurity.SelectedItem = Accountsecurity;
            cboStatus.SelectedItem = Accountstatus;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtAcName.Text.Length < 3)
            {
                MessageBox.Show("Account Name should not be Empty.");
                return;
            }
           
            if (cboCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Should Choose Category");
                return;
            }

            if (cboIsLink.SelectedIndex == 2 && txtEmail.Text == "")
            {  
                    MessageBox.Show("Email field is blank.");
                    return; 
            }

            if (cboSecurity.SelectedIndex == 0)
            {
                MessageBox.Show("Should Choose Security Level");
                return;
            }

            if (lblHeader.Text == dataAdd)
            {
                DataAccount dac = new DataAccount(txtAcName.Text.Trim(), txtUserId.Text.Trim(), txtPassword.Text.Trim(), txtMobile.Text.Trim(), txtEmail.Text, cboCategory.Text.Trim(), cboIsLink.Text.Trim(), cboSecurity.Text.Trim(), cboStatus.Text.Trim());
                DatabaseModel.AddAccountData(dac);
                ClearInfo();
            }
            if (lblHeader.Text == dataUpdate)
            {
                DataAccount dac = new DataAccount(txtAcName.Text.Trim(), txtUserId.Text.Trim(), txtPassword.Text.Trim(), txtMobile.Text.Trim(), txtEmail.Text, cboCategory.Text.Trim(), cboIsLink.Text.Trim(), cboSecurity.Text.Trim(), cboStatus.Text.Trim());
                DatabaseModel.UpdateAccountData(dac, Refid);
                ClearInfo();
            }
            _parent.DisplayInfo();

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInfo();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete data?", "Information", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {      
                DatabaseModel.DeleteAccountData(Refid);
                ClearInfo();
                _parent.DisplayInfo();

            }
            return;
            
        }

    }
}
