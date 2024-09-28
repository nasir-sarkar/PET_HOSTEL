﻿using System;
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
    public partial class Registration : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=ISTIAQ\SQLEXPRESS;Integrated Security=True;Encrypt=False");

        public Registration()
        {
            InitializeComponent();
        }

        private void signup_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void register_login_Click(object sender, EventArgs e)
        {
            Login lForm1 = new Login();
            lForm1.Show();
            this.Hide();
        }

        private void signup_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_username.Text == ""
                || signup_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsValidEmail(signup_email.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (signup_password.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((DateTime.Now.Year - signup_dob.Value.Year) < 15 ||
             (DateTime.Now.Year - signup_dob.Value.Year == 15 && DateTime.Now.DayOfYear < signup_dob.Value.DayOfYear))
            {
                MessageBox.Show("You must be at least 15 years old to register", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else


            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    String checkUsername = "SELECT * FROM admin WHERE username = '"
                            + signup_username.Text.Trim() + "'";

                    using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show(signup_username.Text + " is already exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO admin (email, username, password, dob, date_created) " +
                                "VALUES(@email, @username, @pass, @dob, @date)";

                            DateTime date = DateTime.Today.Date;



                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", signup_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@dob", signup_dob.Value);
                                cmd.Parameters.AddWithValue("@date", date);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Login lForm1 = new Login();
                                lForm1.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Login lForm1 = new Login();
            lForm1.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void signup_dob_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
