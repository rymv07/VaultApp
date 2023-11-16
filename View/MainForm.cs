using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.Model;
using VaultApp.View;

namespace VaultApp
{
    public partial class MainForm : Form, IMessageFilter //IMessageFilter for dragging form
    {

        AccountForm accountForm;
        BackupForm backupForm;
        PersonalForm personalForm;
        CreditsForm creditsForm;

        public MainForm()
        {
            InitializeComponent();
            accountForm = new AccountForm(this);
            backupForm = new BackupForm(this);
            personalForm = new PersonalForm(this);
            creditsForm = new CreditsForm(this);

            //this allows to the form to be dragged
            Application.AddMessageFilter(this);

            //controlsToMove.Add(this);
            controlsToMove.Add(this.panelVault);//Add whatever controls here you want to move the form when it is clicked and dragged
                                                // end of dragging

        }

        //this allows to the form to be dragged
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private HashSet<Control> controlsToMove = new HashSet<Control>();

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN &&
                 controlsToMove.Contains(Control.FromHandle(m.HWnd)))
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return true;
            }
            return false;
        }
        // end of dragging

        // Mainform Load
        private void MainForm_Shown(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            lblTime.Text = date.ToString();
        }


        // Methods
        public void DisplayInfo()
        {
            if (tcVault.SelectedTab == tpAccount)
            {
                DatabaseModel.DisplayAccountData("SELECT Refid, Accountname, Accountuser, Accountpass, Accountmobile, Accountemail, Accountcategory, Accountlink, Accountsecurity, Accountstatus FROM vdb", dgvAccount);
            }

            if (tcVault.SelectedTab == tpBackup)
            {
                DatabaseModel.DisplayBackupData("SELECT Backupid, Backupacname, Backupcode, Backupcodetype, Backupcodestatus FROM vbucdb", dgvBackup);
            }

            if (tcVault.SelectedTab == tpPersonal)
            {
                DatabaseModel.DisplayPersonalData("SELECT Pid, Paccountname, Paccountdetails, Pmobile, Pemail FROM vpdb", dgvPersonal);
            }

            if (tcVault.SelectedTab == tpCredits)
            {
                DatabaseModel.DisplayCreditData("SELECT Creditid, Creditname, Creditamount, Creditdesc, Creditstatus FROM vcrdb", dgvCredits);
            }

            if (tcVault.SelectedTab == tpAdmin)
            {
                DatabaseModel.DisplayCategory("SELECT Categoryid, Categoryname FROM vcdb", dgvCategory);
            }

        }


        // Primary Controls
        // This is to Search the Data
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (tcVault.SelectedTab == tpAccount)
            {
                if (txtSearch.Text == "")
                {
                    DatabaseModel.DisplayAccountData("SELECT Refid, Accountname, Accountuser, Accountpass, Accountmobile, Accountemail, Accountcategory, Accountlink, Accountsecurity, Accountstatus FROM vdb WHERE Refid = '' ", dgvAccount);

                }
                else
                {
                    DatabaseModel.DisplayAccountData("SELECT Refid, Accountname, Accountuser, Accountpass, Accountmobile, Accountemail, Accountcategory, Accountlink, Accountsecurity, Accountstatus FROM vdb WHERE Accountname LIKE '%" + txtSearch.Text + "%' OR Accountcategory LIKE '%" + txtSearch.Text + "%'  ", dgvAccount);
                }
            }

            if (tcVault.SelectedTab == tpBackup)
            {
                if (txtSearch.Text == "")
                {
                    DatabaseModel.DisplayBackupData("SELECT Backupid, Backupacname, Backupcode, Backupcodetype, Backupcodestatus FROM vbucdb WHERE Backupid = '' ", dgvBackup);
                }
                else
                {
                    DatabaseModel.DisplayBackupData("SELECT Backupid, Backupacname, Backupcode, Backupcodetype, Backupcodestatus FROM vbucdb WHERE Backupacname LIKE '%" + txtSearch.Text + "%'", dgvBackup);
                }

            }

            if (tcVault.SelectedTab == tpPersonal)
            {
                if (txtSearch.Text == "")
                {
                    DatabaseModel.DisplayPersonalData("SELECT Pid, Paccountname, Paccountdetails, Pmobile, Pemail FROM vpdb WHERE Pid = '' ", dgvPersonal);
                }
                else
                {
                    DatabaseModel.DisplayPersonalData("SELECT Pid, Paccountname, Paccountdetails, Pmobile, Pemail FROM vpdb WHERE Paccountname LIKE '%" + txtSearch.Text + "%'", dgvPersonal);
                }

            }

            if (tcVault.SelectedTab == tpCredits)
            {
                if (txtSearch.Text == "")
                {
                    DatabaseModel.DisplayCreditData("SELECT Creditid, Creditname, Creditamount, Creditdesc, Creditstatus FROM vcrdb WHERE Creditid = '' ", dgvCredits);
                }
                else
                {
                    DatabaseModel.DisplayCreditData("SELECT Creditid, Creditname, Creditamount, Creditdesc, Creditstatus FROM vcrdb WHERE Creditname LIKE '%" + txtSearch.Text + "%'", dgvCredits);
                }
            }




        }

        // This is to Display all Data
        private void btnView_Click(object sender, EventArgs e)
        {
            DisplayInfo();

        }

        // This is to Pop up form to add data
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tcVault.SelectedTab == tpAccount)
            {
                accountForm.ClearInfo();
                accountForm.AddInfo();
                accountForm.ShowDialog(this);
            }

            if (tcVault.SelectedTab == tpBackup)
            {
                backupForm.ClearBackinfo();
                backupForm.AddBackInfo();
                backupForm.ShowDialog(this);
            }

            if (tcVault.SelectedTab == tpPersonal)
            {
                personalForm.ClearPinfo();
                personalForm.AddPersonalInfo();
                personalForm.ShowDialog(this);
            }

            if (tcVault.SelectedTab == tpCredits)
            {
                creditsForm.ClearCinfo();
                creditsForm.AddCreditInfo();
                creditsForm.ShowDialog(this);
            }


        }

        // This is to Log out to this App
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Log out?", "Information", MessageBoxButtons.YesNo,
             MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
                
            }

            
        }


        //Account Tab dataGridView function
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                accountForm.ClearInfo();
                accountForm.Refid = dgvAccount.Rows[e.RowIndex].Cells[1].Value.ToString();
                accountForm.Accountname = dgvAccount.Rows[e.RowIndex].Cells[2].Value.ToString();
                accountForm.Accountuser = dgvAccount.Rows[e.RowIndex].Cells[3].Value.ToString();
                accountForm.Accountpass = dgvAccount.Rows[e.RowIndex].Cells[4].Value.ToString();
                accountForm.Accountmobile = dgvAccount.Rows[e.RowIndex].Cells[5].Value.ToString();
                accountForm.Accountemail = dgvAccount.Rows[e.RowIndex].Cells[6].Value.ToString();
                accountForm.Accountcategory = dgvAccount.Rows[e.RowIndex].Cells[7].Value.ToString();
                accountForm.Accountlink = dgvAccount.Rows[e.RowIndex].Cells[8].Value.ToString();
                accountForm.Accountsecurity = dgvAccount.Rows[e.RowIndex].Cells[9].Value.ToString();
                accountForm.Accountstatus = dgvAccount.Rows[e.RowIndex].Cells[10].Value.ToString();
                accountForm.UpdateInfo();
                accountForm.ShowDialog();
                return;
            }
        }

        //Backup Tab dataGridView function
        private void dgvBackup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                backupForm.ClearBackinfo();
                backupForm.Backupid = dgvBackup.Rows[e.RowIndex].Cells[1].Value.ToString();
                backupForm.Backupacname = dgvBackup.Rows[e.RowIndex].Cells[2].Value.ToString();
                backupForm.Backupcode = dgvBackup.Rows[e.RowIndex].Cells[3].Value.ToString();
                backupForm.Backupcodetype = dgvBackup.Rows[e.RowIndex].Cells[4].Value.ToString();
                backupForm.Backupcodestatus = dgvBackup.Rows[e.RowIndex].Cells[5].Value.ToString();
                backupForm.UpdateBackInfo();
                backupForm.ShowDialog();
                return;
            }
        }

        //Personal Tab dataGridView function
        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                personalForm.ClearPinfo();
                personalForm.Pid = dgvPersonal.Rows[e.RowIndex].Cells[1].Value.ToString();
                personalForm.Paccountname = dgvPersonal.Rows[e.RowIndex].Cells[2].Value.ToString();
                personalForm.Paccountdetails = dgvPersonal.Rows[e.RowIndex].Cells[3].Value.ToString();
                personalForm.Pmobile = dgvPersonal.Rows[e.RowIndex].Cells[4].Value.ToString();
                personalForm.Pemail = dgvPersonal.Rows[e.RowIndex].Cells[5].Value.ToString();
                personalForm.UpdatePersonalInfo();
                personalForm.ShowDialog();
                return;
            }
        }

        // Credit Tab dataGridView function
        private void dgvCredits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                creditsForm.ClearCinfo();
                creditsForm.Creditid = dgvCredits.Rows[e.RowIndex].Cells[1].Value.ToString();
                creditsForm.Creditname = dgvCredits.Rows[e.RowIndex].Cells[2].Value.ToString();
                creditsForm.Creditamount = dgvCredits.Rows[e.RowIndex].Cells[3].Value.ToString();
                creditsForm.Creditdesc = dgvCredits.Rows[e.RowIndex].Cells[4].Value.ToString();
                creditsForm.Creditstatus = dgvCredits.Rows[e.RowIndex].Cells[5].Value.ToString();
                creditsForm.UpdateCreditInfo();
                creditsForm.ShowDialog();
                return;
            }
        }


        // Category 

        private void btnsavenewcat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to Add Category, Do you want to continue?", "Information", MessageBoxButtons.YesNo,
             MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataCategory dcat = new DataCategory(txtaddcat.Text.Trim());
                DatabaseModel.AddCategory(dcat);
                DisplayInfo();
            }
            return;
        }

        private void btnshowcat_Click(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (MessageBox.Show("This will delete the data permanently. If you know what you are doing, you may continue.", "Information", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DatabaseModel.DeleteCategory(dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DisplayInfo();
                }
            }

        }

        // End of Category

        // Change password

        string userid;
        public string Userid { get => userid; set => userid = value; }




        private void cbshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshowpass.Checked)
            {
                txtnewpass.UseSystemPasswordChar = false;
                txtconfpass.UseSystemPasswordChar = false;
            } else
            {
                txtnewpass.UseSystemPasswordChar = true;
                txtconfpass.UseSystemPasswordChar = true;
            }

        }

        private void btnsavenewpass_Click(object sender, EventArgs e)
        {
            if (txtnewpass.Text.Length < 4 || txtconfpass.Text.Length < 4)
            {
                lblchnotif.Enabled = true;
                lblchnotif.Visible = true;
                lblchnotif.Text = "Password too short!";
                return;
            }

            if (txtnewpass.Text != txtconfpass.Text)
            {
                lblchnotif.Enabled = true;
                lblchnotif.Visible = true;
                lblchnotif.Text = "Password not match";
                return;
            } else
            {
                lblchnotif.Enabled = false;
                lblchnotif.Visible = false;

                if (MessageBox.Show("Are you sure you want to change password?", "Information", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DataUser du = new DataUser(txtnewpass.Text.Trim());
                    DatabaseModel.UpdateUser(du, Userid);
                }
            }


        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtnewpass.Text = txtconfpass.Text    = string.Empty;
        }



        // End of Change Password
    }
    
}
