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

namespace PET_HOSTEL
{
    public partial class UserPanel : Form
    {
       private SqlConnection connect;
        private bool isTotalChecked = false;
        

        public UserPanel()
        {
            InitializeComponent();
            DataAccess dataAccess = new DataAccess();
            connect = new SqlConnection(dataAccess.GetConnectionString());
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (!isTotalChecked)
            {
                MessageBox.Show("Please check the total amount first.");
                return;
            }

            if (string.IsNullOrEmpty(username.Text) || petType.SelectedIndex == -1 || age.SelectedIndex == -1 || injectionStatus.SelectedIndex == -1 || medicineNeeded.SelectedIndex == -1 || startDate.Value == null || checkoutDate.Value == null)
            {
                MessageBox.Show("All fields must be filled.");
                return; 
            }

            int totalAmount = 0;

            switch (petType.SelectedItem.ToString())
            {
                case "Cat": totalAmount += 600; break;
                case "Dog": totalAmount += 700; break;
                case "Rabbit": totalAmount += 500; break;
                case "Tortoise": totalAmount += 650; break;
                case "Hamster": totalAmount += 800; break;
                case "Bird": totalAmount += 400; break;
                case "Fish": totalAmount += 450; break;
            }


            switch (age.SelectedItem.ToString())
            {
                case "Up to 5 months": totalAmount += 150; break;
                case "Up to 1 year": totalAmount += 250; break;
                case "Up to 3 years": totalAmount += 350; break;
                case "Up to 5 years": totalAmount += 450; break;
                case "More than 5 years": totalAmount += 480; break;
            }


            if (injectionStatus.SelectedItem.ToString() == "No")
            {
                totalAmount += 500;
            }

            if (medicineNeeded.SelectedItem.ToString() == "Yes")
            {
                totalAmount += 300;
            }

            TimeSpan dateDifference = checkoutDate.Value.Date - startDate.Value.Date;
            int days = dateDifference.Days;

            if (days == 0)
            {
                days = 1;
            }
            if (days > 0)
            {
                totalAmount += days * 300;
            }


            try
            {
                connect.Open();
                string query = "UPDATE admin SET pet = @pet, pet_age = @age, injection_status = @injectionStatus, medicine_needed = @medicineNeeded, start_date = @startDate, checkout_date = @checkoutDate, payment_amount = @totalAmount, payment_status = @paymentStatus WHERE username = @username";

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@pet", petType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@age", age.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@injectionStatus", injectionStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@medicineNeeded", medicineNeeded.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@startDate", startDate.Value);
                cmd.Parameters.AddWithValue("@checkoutDate", checkoutDate.Value);
                cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                cmd.Parameters.AddWithValue("@paymentStatus", "unpaid");
                cmd.Parameters.AddWithValue("@username", username.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    PaymentMethod z = new PaymentMethod();
                    z.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error saving data or username not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }           
           
        }


        private void username_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            
            username.Text = string.Empty;

         
            petType.SelectedIndex = -1;  
            age.SelectedIndex = -1;
            injectionStatus.SelectedIndex = -1;
            medicineNeeded.SelectedIndex = -1;

           
            startDate.Value = DateTime.Now;
            checkoutDate.Value = DateTime.Now;

            isTotalChecked = false;
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_TotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void label_Check_Click(object sender, EventArgs e)
        {
           
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            Login lForm1 = new Login();
            lForm1.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_CheckTotal_Click(object sender, EventArgs e)
        {          
            if (string.IsNullOrEmpty(username.Text) || petType.SelectedIndex == -1 || age.SelectedIndex == -1 || injectionStatus.SelectedIndex == -1 || medicineNeeded.SelectedIndex == -1 || startDate.Value == null || checkoutDate.Value == null)
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            int totalAmount = 0;

            
            switch (petType.SelectedItem.ToString())
            {
                case "Cat": totalAmount += 600; break;
                case "Dog": totalAmount += 700; break;
                case "Rabbit": totalAmount += 500; break;
                case "Tortoise": totalAmount += 650; break;
                case "Hamster": totalAmount += 800; break;
                case "Bird": totalAmount += 400; break;
                case "Fish": totalAmount += 450; break;
            }

           
            switch (age.SelectedItem.ToString())
            {
                case "Up to 5 months": totalAmount += 150; break;
                case "Up to 1 year": totalAmount += 250; break;
                case "Up to 3 years": totalAmount += 350; break;
                case "Up to 5 years": totalAmount += 450; break;
                case "More than 5 years": totalAmount += 480; break;
            }

          
            if (injectionStatus.SelectedItem.ToString() == "No")
            {
                totalAmount += 500;
            }

          
            if (medicineNeeded.SelectedItem.ToString() == "Yes")
            {
                totalAmount += 300;
            }


            TimeSpan dateDifference = checkoutDate.Value.Date - startDate.Value.Date;
            int days = dateDifference.Days;

            if (days == 0)
            {
                days = 1;
            }
            if (days > 0)
            {
                totalAmount += days * 300;
            }


            MessageBox.Show($"Total Amount: {totalAmount} Taka", "Total Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);        
            isTotalChecked = true;
        }
    }

}
