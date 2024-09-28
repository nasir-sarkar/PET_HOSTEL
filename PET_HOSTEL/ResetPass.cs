using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class ResetPass : Form
    {
        private string randomCode;
        public static string to;

        // Database connection string
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\naimur\OneDrive\Documents\logindata.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        public ResetPass()
        {
            InitializeComponent();
        }

        private void ResetPass_Load(object sender, EventArgs e)
        {
        }

        private void sotp_Click(object sender, EventArgs e)
        {
            // Check if email exists in the database
            if (IsEmailRegistered(temail.Text))
            {
                // Send OTP to email
                randomCode = GenerateOtp();
                bool isEmailSent = SendOtpEmail(temail.Text, randomCode);

                if (isEmailSent)
                {
                    MessageBox.Show("Code sent successfully");
                }
                else
                {
                    MessageBox.Show("Failed to send code.");
                }
            }
            else
            {
                MessageBox.Show("No user found with this email.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (randomCode == tverify.Text)
            {
                to = temail.Text;
                MessageBox.Show("Verification successful!");

                // Show new form for password reset
                Changepasss cp = new Changepasss();
                cp.UserEmail = to;  // Pass the email to the Changepasss form
                cp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void temail_TextChanged(object sender, EventArgs e)
        {
        }

        // Function to generate a random OTP
        private string GenerateOtp()
        {
            Random rand = new Random();
            return (rand.Next(100000, 999999)).ToString();
        }

        // Function to send OTP email
        private bool SendOtpEmail(string toEmail, string otp)
        {
            try
            {
                string from = "mrx999888@gmail.com";  // Replace with your email
                string pass = "flgm qnoc hwms gzop";  // Replace with your app-specific password
                string subject = "Password Reset Code";
                string body = $"Your reset code is {otp}";

                MailMessage message = new MailMessage();
                message.To.Add(toEmail);
                message.From = new MailAddress(from);
                message.Subject = subject;
                message.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(from, pass)
                };

                smtp.Send(message);  // Send email
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send code: " + ex.Message);  // Handle email errors
                return false;
            }
        }

        // Function to check if the email exists in the database
        private bool IsEmailRegistered(string email)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM admin WHERE Email = @Email";
                connect.Open();

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)command.ExecuteScalar();

                    connect.Close();
                    return count > 0;  // Return true if the email exists, false otherwise
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
            }
            finally
            {
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login logi = new Login();
            logi.Show();
            this.Hide();
        }
    }
}
