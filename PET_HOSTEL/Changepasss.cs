using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class Changepasss : Form
    {
        private readonly string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\naimur\OneDrive\Documents\logindata.mdf;Integrated Security = True; Connect Timeout = 30; Encrypt=False";

        public string UserEmail { get; set; } // Property to hold the user's email
        public Changepasss()
        {
            InitializeComponent();
        }

        private void updt_Click(object sender, EventArgs e)
        {
            if (npass.Text != cpass.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            // Display the email for debugging
            MessageBox.Show($"Updating password for: {UserEmail}");

            // Update the password in the database
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string query = "UPDATE admin SET password = @Password WHERE email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@Password", npass.Text); // New password
                        command.Parameters.AddWithValue("@Email", UserEmail); // User's email

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                            this.Close(); // Close the form after update
                        }
                        else
                        {
                            MessageBox.Show("Error: User not found or password not updated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }

        }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                if (sp.Checked)
                {
                    npass.PasswordChar = '\0';
                    cpass.PasswordChar = '\0';
                }
                else
                {
                    npass.PasswordChar = '*';
                    cpass.PasswordChar = '*';
                }

            }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    } }

