using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaultApp.View;

namespace VaultApp.Model
{
    internal class DatabaseModel
    {

        public static SqlCommand cmd;

       
        // Established Connection SQL Server
        public static SqlConnection GetConnection()
        {
            string sql = @"Data Source=CIN\SQLEXPRESS;Initial Catalog=mvdb;Persist Security Info=True;User ID=sa;Password=msadmin";

            SqlConnection con = new SqlConnection(sql);

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return con;
        }

        // Database Configuration Account Form

        // To Add data to Account Form
        public static void AddAccountData(DataAccount dac)
        {
            string avt = "Account";

            string sql = "INSERT INTO vdb VALUES (@accountname, @accountuser, @accountpass, @accountmobile, @accountemail, @accountlink, @accountcategory, @accountsecurity, @accountstatus, @accountvaulttype, getdate(), getdate())";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@accountname", SqlDbType.VarChar).Value = dac.Accountname;
            cmd.Parameters.Add("@accountuser", SqlDbType.VarChar).Value = dac.Accountuser;
            cmd.Parameters.Add("@accountpass", SqlDbType.VarChar).Value = dac.Accountpass;
            cmd.Parameters.Add("@accountmobile", SqlDbType.VarChar).Value = dac.Accountmobile;
            cmd.Parameters.Add("@accountemail", SqlDbType.VarChar).Value = dac.Accountemail;
            cmd.Parameters.Add("@accountlink", SqlDbType.VarChar).Value = dac.Accountlink;
            cmd.Parameters.Add("@accountcategory", SqlDbType.VarChar).Value = dac.Accountcategory;
            cmd.Parameters.Add("@accountsecurity", SqlDbType.VarChar).Value = dac.Accountsecurity;
            cmd.Parameters.Add("@accountstatus", SqlDbType.VarChar).Value = dac.Accountstatus;
            cmd.Parameters.Add("@accountvaulttype", SqlDbType.VarChar).Value = avt;

            Savetc();
            con.Close();

        }

        // To Update or Modify Data from Account Form
        public static void UpdateAccountData(DataAccount dac, string Refid)
        {
            
            string sql = "UPDATE vdb SET Accountname = @accountname, Accountuser = @accountuser, Accountpass = @accountpass, Accountmobile = @accountmobile, Accountemail = @accountemail, Accountlink = @accountlink, Accountcategory = @accountcategory, Accountsecurity = @accountsecurity, Accountstatus = @accountstatus WHERE Refid = @refid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@refid", SqlDbType.VarChar).Value = Refid;
            cmd.Parameters.Add("@accountname", SqlDbType.VarChar).Value = dac.Accountname;
            cmd.Parameters.Add("@accountuser", SqlDbType.VarChar).Value = dac.Accountuser;
            cmd.Parameters.Add("@accountpass", SqlDbType.VarChar).Value = dac.Accountpass;
            cmd.Parameters.Add("@accountmobile", SqlDbType.VarChar).Value = dac.Accountmobile;
            cmd.Parameters.Add("@accountemail", SqlDbType.VarChar).Value = dac.Accountemail;
            cmd.Parameters.Add("@accountlink", SqlDbType.VarChar).Value = dac.Accountlink;
            cmd.Parameters.Add("@accountcategory", SqlDbType.VarChar).Value = dac.Accountcategory;
            cmd.Parameters.Add("@accountsecurity", SqlDbType.VarChar).Value = dac.Accountsecurity;
            cmd.Parameters.Add("@accountstatus", SqlDbType.VarChar).Value = dac.Accountstatus;



            Updatetc();
            con.Close();

        }

        // To Delete Data from Account Form
        public static void DeleteAccountData(string Refid)
        {
            string sql = "DELETE FROM vdb WHERE Refid = @refid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@refid", SqlDbType.VarChar).Value = Refid;

            Deletetc();
            con.Close();

        }

        // To Display Data from Account Form
        public static void DisplayAccountData(string query, DataGridView dgvVault)
        {
            string sql = query;
            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvVault.DataSource = dt;
            con.Close();
        }

        // End of Database Configuration Account Form

        // Database Configuration Backup Form


        public static void AddBackupData(DataBackup dbu)
        {
            string buvt = "Backup Code";

            string sql = "INSERT INTO vbucdb VALUES (@backupacname, @backupcode, @backupcodetype, @backupcodestatus, @backupvaulttype , getdate(), getdate())";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@backupacname", SqlDbType.VarChar).Value = dbu.Backupacname;
            cmd.Parameters.Add("@backupcode", SqlDbType.VarChar).Value = dbu.Backupcode;
            cmd.Parameters.Add("@backupcodetype", SqlDbType.VarChar).Value = dbu.Backupcodetype;
            cmd.Parameters.Add("@backupcodestatus", SqlDbType.VarChar).Value = dbu.Backupcodestatus;
            cmd.Parameters.Add("@backupvaulttype", SqlDbType.VarChar).Value = buvt;

            Savetc();
            con.Close();

        }


        public static void UpdateBackupData(DataBackup dbu, string Backupid)
        {
            string sql = "UPDATE vbucdb SET Backupacname = @backupacname, Backupcode = @backupcode, Backupcodetype = @backupcodetype, Backupcodestatus = @backupcodestatus WHERE Backupid = @backupid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@backupid", SqlDbType.VarChar).Value = Backupid;
            cmd.Parameters.Add("@backupacname", SqlDbType.VarChar).Value = dbu.Backupacname;
            cmd.Parameters.Add("@backupcode", SqlDbType.VarChar).Value = dbu.Backupcode;
            cmd.Parameters.Add("@backupcodetype", SqlDbType.VarChar).Value = dbu.Backupcodetype;
            cmd.Parameters.Add("@backupcodestatus", SqlDbType.VarChar).Value = dbu.Backupcodestatus;

            Updatetc();
            con.Close();

        }

   
        public static void DisplayBackupData(string query, DataGridView dgvBackup)
        {
            string sql = query;
            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBackup.DataSource = dt;
            con.Close();
        }

        // End of Database Configuration Backup Form

        // Database Configuration Personal Form
        public static void AddPersonalData(DataPersonal dp)
        {
            string pvt = "Personal";

            string sql = "INSERT INTO vpdb VALUES (@paccountname, @paccountdetails, @pmobile, @pemail, @pvaulttype, getdate(), getdate())";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@paccountname", SqlDbType.VarChar).Value = dp.Paccountname;
            cmd.Parameters.Add("@paccountdetails", SqlDbType.VarChar).Value = dp.Paccountdetails;
            cmd.Parameters.Add("@pmobile", SqlDbType.VarChar).Value = dp.Pmobile;
            cmd.Parameters.Add("@pemail", SqlDbType.VarChar).Value = dp.Pemail;
            cmd.Parameters.Add("@pvaulttype", SqlDbType.VarChar).Value = pvt;

            Savetc();
            con.Close();

        }


        public static void UpdatePersonalData(DataPersonal dp, string Pid)
        {
            string sql = "UPDATE vpdb SET Paccountname = @paccountname, Paccountdetails = @paccountdetails, Pmobile = @pmobile, Pemail = @pemail WHERE Pid = @pid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = Pid;
            cmd.Parameters.Add("@paccountname", SqlDbType.VarChar).Value = dp.Paccountname;
            cmd.Parameters.Add("@paccountdetails", SqlDbType.VarChar).Value = dp.Paccountdetails;
            cmd.Parameters.Add("@pmobile", SqlDbType.VarChar).Value = dp.Pmobile;
            cmd.Parameters.Add("@pemail", SqlDbType.VarChar).Value = dp.Pemail;

            Updatetc();
            con.Close();

        }

        public static void DisplayPersonalData(string query, DataGridView dgvPersonal)
        {
            string sql = query;
            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPersonal.DataSource = dt;
            con.Close();
        }

        // End of Database Configuration Personal Form


        // Database Configuration Credit Form

        public static void AddCreditData(DataCredit dc)
        {
            string crvt = "Credits";

            string sql = "INSERT INTO vcrdb VALUES (@creditname, @creditamount, @creditdesc, @creditstatus, @creditvaulttype, getdate(), getdate())";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@creditname", SqlDbType.VarChar).Value = dc.Creditname;
            cmd.Parameters.Add("@creditamount", SqlDbType.Float).Value = dc.Creditamount;
            cmd.Parameters.Add("@creditdesc", SqlDbType.VarChar).Value = dc.Creditdesc;
            cmd.Parameters.Add("@creditstatus", SqlDbType.VarChar).Value = dc.Creditstatus;
            cmd.Parameters.Add("@creditvaulttype", SqlDbType.VarChar).Value = crvt;


            Savetc();
            con.Close();

        }

        public static void UpdateCreditData(DataCredit dc, string Creditid)
        {
            string sql = "UPDATE vcrdb SET Creditname = @creditname, Creditamount = @creditamount, Creditdesc = @creditdesc, Creditstatus = @creditstatus WHERE Creditid = @creditid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@creditid", SqlDbType.VarChar).Value = Creditid;
            cmd.Parameters.Add("@creditname", SqlDbType.VarChar).Value = dc.Creditname;
            cmd.Parameters.Add("@creditamount", SqlDbType.VarChar).Value = dc.Creditamount;
            cmd.Parameters.Add("@creditdesc", SqlDbType.VarChar).Value = dc.Creditdesc;
            cmd.Parameters.Add("@creditstatus", SqlDbType.VarChar).Value = dc.Creditstatus;

            Updatetc();
            con.Close();

        }

        public static void DisplayCreditData(string query, DataGridView dgvCredits)
        {
            string sql = query;
            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCredits.DataSource = dt;
            con.Close();
        }

        // End of Database Configuration Credit Form


        // Database Configuration Category

        public static void AddCategory(DataCategory dcat)
        {
            string cat = "Category";

            string sql = "INSERT INTO vcdb VALUES (@categoryname, @categoryvtype, getdate())";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@categoryname", SqlDbType.VarChar).Value = dcat.Categoryname;
            cmd.Parameters.Add("@categoryvtype", SqlDbType.VarChar).Value = cat;

            Savetc();
            con.Close();

        }

        public static void DeleteCategory(string Categoryid)
        {
            string sql = "DELETE FROM vcdb WHERE Categoryid = @categoryid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@categoryid", SqlDbType.VarChar).Value = Categoryid;

            Deletetc();
            con.Close();

        }

        public static void DisplayCategory(string query, DataGridView dgvCategory)
        {
            string sql = query;
            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCategory.DataSource = dt;
            con.Close();
        }


        // End of Database Configuration Category


        // Database Change Password

        public static void UpdateUser(DataUser du, string Userid)
        {
            Userid = "3000";

            string sql = "UPDATE vusr SET Userpass = @userpass WHERE Userid = @userid";

            SqlConnection con = GetConnection();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = Userid;
            cmd.Parameters.Add("@userpass", SqlDbType.VarChar).Value = du.Userpass;
          
            Updatetc();
            con.Close();

        }

        // End of Change Password

        // Try Catch Methods
        public static void Savetc()
        {
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Process Unsuccessful. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Updatetc()
        {
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Process Unsuccessful. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Deletetc()
        {
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Process Unsuccessful. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

    }
}
