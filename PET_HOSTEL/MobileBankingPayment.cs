using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PET_HOSTEL
{
    public partial class MobileBankingPayment : Form
    {
<<<<<<< HEAD
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ABU JAFAR SISTY\Documents\pet hostel.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");
=======
        SqlConnection connect = new SqlConnection(@"Data Source=ISTIAQ\SQLEXPRESS;Integrated Security=True;Encrypt=False");
>>>>>>> 0bd3a038f08d61242022148a2d29b260138b3ce8
        private bool isPaymentConfirmed = false;

        public MobileBankingPayment()
        {
            InitializeComponent();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txt_Username.Text) ||
                string.IsNullOrEmpty(text_Amount.Text) ||
                string.IsNullOrEmpty(text_Card.Text) ||
                string.IsNullOrEmpty(text_Pin.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!int.TryParse(text_Amount.Text, out int amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                
                connect.Open();


                string query = "SELECT payment_amount FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Username not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int paymentAmount = (int)result;

                if (paymentAmount == amount)
                {
                    string updateQuery = "UPDATE admin SET payment_status = 'Paid' WHERE username = @username";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connect);
                    updateCmd.Parameters.AddWithValue("@username", txt_Username.Text);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Payment confirmed successfully and status updated to 'Paid'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isPaymentConfirmed = true;
                }
                else
                {
                    string clearFieldsQuery = "UPDATE admin SET pet = NULL, pet_age = NULL, injection_status = NULL, medicine_needed = NULL, start_date = NULL, checkout_date = NULL, payment_amount = 0 WHERE username = @username";
                    SqlCommand clearFieldsCmd = new SqlCommand(clearFieldsQuery, connect);
                    clearFieldsCmd.Parameters.AddWithValue("@username", txt_Username.Text);
                    clearFieldsCmd.ExecuteNonQuery();

                    MessageBox.Show("You entered the wrong amount. Please book again and check the total amount from the beginning.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    UserPanel WForm1 = new UserPanel();
                    WForm1.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {              
                connect.Close();
            }
        }

        private void MobileBankingPayment_Load(object sender, EventArgs e)
        {

        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            if (!isPaymentConfirmed)
            {
                MessageBox.Show("Please confirm payment before printing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connect.Open();

                string query = "SELECT username, pet, injection_status, medicine_needed, start_date, checkout_date, payment_amount FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@username", txt_Username.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string petType = reader["pet"].ToString();
                    string injectionStatus = reader["injection_status"].ToString();
                    string medicineNeeded = reader["medicine_needed"].ToString();
                    DateTime startDate = Convert.ToDateTime(reader["start_date"]);
                    DateTime checkoutDate = Convert.ToDateTime(reader["checkout_date"]);
                    int totalAmount = (int)reader["payment_amount"];

                    Random random = new Random();
                    string tokenCode = "PAS" + random.Next(1000, 9999);

                    string printDetails = $"Username: {username}\n" +
                                          $"Pet type: {petType}\n" +
                                          $"Injection Status: {injectionStatus}\n" +
                                          $"Medicine Needed: {medicineNeeded}\n" +
                                          $"Start Date: {startDate.ToShortDateString()}\n" +
                                          $"Checkout Date: {checkoutDate.ToShortDateString()}\n" +
                                          $"Total Amount: {totalAmount} TAKA\n" +
                                          $"Token Code: {tokenCode}";

                    MessageBox.Show(printDetails, "Payment Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string filePath = $@"D:\OOP2PROJECT\Receipts\{username}_PaymentReceipt.txt";


                    Directory.CreateDirectory(@"C:\Receipts");

                    File.WriteAllText(filePath, printDetails);

                    MessageBox.Show($"Receipt saved to {filePath}", "Receipt Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Welcome WForm1 = new Welcome();
                    WForm1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
