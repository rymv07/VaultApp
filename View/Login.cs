using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.Model;

namespace VaultApp.View
{
    public partial class Login : Form
    {

        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader dtread;


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=CIN\SQLEXPRESS;Initial Catalog=mvdb;Persist Security Info=True;User ID=sa;Password=msadmin");
            conn.Open();
        }

        public void LoginAuth()
        {

            if (txtusername.Text != string.Empty || txtpassword.Text != string.Empty)
            {

                cmd = new SqlCommand("SELECT * FROM vusr where username = '" + txtusername.Text + "' AND userpass = '" + txtpassword.Text + "'", conn);
                dtread = cmd.ExecuteReader();

                if (dtread.Read())
                {
                    dtread.Close();
                    this.Hide();
                    MainForm mf = new MainForm();
                    mf.ShowDialog();
                }
                else
                {
                    dtread.Close(); 
                    
                    lblResult.Left = 315;
                    lblResult.Enabled = true;
                    lblResult.Visible = true;
                    lblResult.Text = "Login Failed!";
                    return;
                }
              
            } 
            else 
            {
                lblResult.Left = 305;
                lblResult.Enabled = true;
                lblResult.Visible = true;
                lblResult.Text = "Blank Fields!";
            }

        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginAuth();
        }

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.Text != string.Empty || txtpassword.Text != string.Empty)
            {
                lblResult.Enabled = false;
                lblResult.Visible = false;
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtusername.Text != string.Empty || txtpassword.Text != string.Empty)
            {
                lblResult.Enabled = false;
                lblResult.Visible = false;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.OpenMainFormOnClose = true;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();

        }
    }
}
