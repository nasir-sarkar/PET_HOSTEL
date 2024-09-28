using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class Login: Form
    {

        private SqlConnection connect;

        public Login()
        {
            InitializeComponent();
            DataAccess dataAccess = new DataAccess();
            connect = new SqlConnection(dataAccess.GetConnectionString());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_register_Click(object sender, EventArgs e)
        {
            Registration sForm = new Registration();
            sForm.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showPass.Checked)
            {
                login_password.PasswordChar = '\0';
            }
            else
            {
                login_password.PasswordChar = '*';
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();


                    string selectData = "SELECT username, password, usertype FROM admin WHERE username = @username AND password = @pass";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", login_password.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count == 1)
                        {

                            DataRow row = table.Rows[0];
                            int userType = Convert.ToInt32(row["usertype"]);

                            string updateLoginStatus = "UPDATE admin SET login_status = 1 WHERE username = @username";
                            using (SqlCommand updateCmd = new SqlCommand(updateLoginStatus, connect))
                            {
                                updateCmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                                updateCmd.ExecuteNonQuery();
                            }

                            if (userType == 1)
                            {

                                UserPanel userPanel = new UserPanel();
                                userPanel.Show();
                                this.Hide();
                            }
                            else if (userType == 0)
                            {

                              AdminPanel adminPanel = new AdminPanel();
                                adminPanel.Show();
                              AdminPanel ad=new AdminPanel();
                                ad.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Unknown user type", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void login_close_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome WForm1 = new Welcome();
            WForm1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration sForm = new Registration();
            sForm.Show();
            this.Hide();
        }

        private void button_Join_Click(object sender, EventArgs e)
        {
            Registration sForm = new Registration();
            sForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fb_Click(object sender, EventArgs e)
        {
            ResetPass rp = new ResetPass();
            this.Hide(); rp.Show();
        }
    }
}

