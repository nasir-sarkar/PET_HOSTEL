using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace PET_HOSTEL
{
    public partial class AdminPanel : Form
    {


        private readonly string connectionString;


        public AdminPanel()
        {
            InitializeComponent();
            DataAccess dataAccess = new DataAccess();
            connectionString = dataAccess.GetConnectionString();
            ShowAdminData();
        }
        private void ShowAdminData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM admin";
                   
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                
                    DataTable table = new DataTable();
                 
                    conn.Open();
                 
                    adapter.Fill(table);
                 
                    if (table.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = table;
                    }
                    else
                    {
                        MessageBox.Show("No data found in the admin table.");
                    }
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }

       

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

      


        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databasePetHostelDataSet.admin' table. You can move, or remove it, as needed.
            //this.adminTableAdapter.Fill(this.databasePetHostelDataSet.admin);

        }
        private void btn_Show_Click_1(object sender, EventArgs e)
        {
        
            string username = txt_UsernameSearch.Text.Trim();

             
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username to search.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = "SELECT * FROM admin WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@username", username);

                       
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                       
                        dataGridView1.DataSource = dataTable;

                       
                        signup_email.Text = "";
                        txt_UsernameSearch.Text = "";
                        signup_password.Text = "";
                        signup_dob.Value = DateTime.Today;
                        txt_usertype.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error retrieving data: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void btn_Refresh_Click_1(object sender, EventArgs e)
        {
            ShowAdminData();
        }

        private void btn_Uptate_Click_1(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_username.Text == "")
            {
                MessageBox.Show("Please enter a valid username and email to update.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string updateQuery = "UPDATE admin SET email = @newEmail, password = @newPassword, dob = @newDob, usertype = @newUsertype WHERE username = @username";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@newEmail", signup_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@newPassword", signup_password.Text.Trim());
                            cmd.Parameters.AddWithValue("@newDob", signup_dob.Value);

                            int newUsertype;
                            if (int.TryParse(txt_usertype.Text.Trim(), out newUsertype))
                            {
                                cmd.Parameters.AddWithValue("@newUsertype", newUsertype);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@newUsertype", 1);
                            }

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User information updated successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                signup_email.Text = "";
                                signup_username.Text = "";
                                signup_password.Text = "";
                                signup_dob.Value = DateTime.Today;
                                txt_usertype.Text = "";

                                ShowAdminData();
                            }
                            else
                            {
                                MessageBox.Show("Update failed. User not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Delete_Click_1(object sender, EventArgs e)
        {
            if (signup_username.Text == "")
            {
                MessageBox.Show("Please enter a username to delete.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string deleteQuery = "DELETE FROM admin WHERE username = @username";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User deleted successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                signup_email.Text = "";
                                signup_username.Text = "";
                                signup_password.Text = "";
                                signup_dob.Value = DateTime.Today;
                                txt_usertype.Text = "";

                                ShowAdminData();
                            }
                            else
                            {
                                MessageBox.Show("Delete failed. User not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting data: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void signup_btn_Click_1(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_username.Text == "" || signup_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidEmail(signup_email.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string checkUsername = "SELECT * FROM admin WHERE username = @username";

                        using (SqlCommand checkUser = new SqlCommand(checkUsername, conn))
                        {
                            checkUser.Parameters.AddWithValue("@username", signup_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(signup_username.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO admin (email, username, password, dob, usertype, date_created) " +
                                    "VALUES(@email, @username, @pass, @dob, @usertype, @date)";

                                DateTime date = DateTime.Today;

                                using (SqlCommand cmd = new SqlCommand(insertData, conn))
                                {
                                    cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dob", signup_dob.Value);
                                    cmd.Parameters.AddWithValue("@date", date);

                                    int userType;
                                    if (int.TryParse(txt_usertype.Text.Trim(), out userType))
                                    {
                                        cmd.Parameters.AddWithValue("@usertype", userType);
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@usertype", 1);
                                    }

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    signup_email.Text = "";
                                    signup_username.Text = "";
                                    signup_password.Text = "";
                                    signup_dob.Value = DateTime.Today;
                                    txt_usertype.Text = "";

                                    signup_email.Focus();
                                    ShowAdminData();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
 

        private void signup_showPass_CheckedChanged_1(object sender, EventArgs e)
        {
            if (signup_showPass.Checked)
            {
                signup_password.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
            }
        }

<<<<<<< HEAD
        private void signup_password_TextChanged(object sender, EventArgs e)
        {

        }
=======
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
            
        }

>>>>>>> 496c5df1989eab9110369a84ef1ca5fe23388f53
    }
}
