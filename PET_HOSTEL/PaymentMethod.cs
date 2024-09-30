using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PET_HOSTEL
{
    public partial class PaymentMethod : Form
    {
        public PaymentMethod()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void visa_Click(object sender, EventArgs e)
        {
            CardPayment a = new CardPayment();
            a.Show();         
        }

        private void masterCard_Click(object sender, EventArgs e)
        {
            CardPayment b = new CardPayment();
            b.Show();         
        }

        private void payPal_Click(object sender, EventArgs e)
        {
            CardPayment c = new CardPayment();
            c.Show();
        }

        private void bkash_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment();
            d.Show();
        }

        private void nogod_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment();
            d.Show();         
        }

        private void rocked_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment();
            d.Show();
        }

        private void upay_Click(object sender, EventArgs e)
        {
            MobileBankingPayment d = new MobileBankingPayment();
            d.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CardPayment f = new CardPayment();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

       
        private void backBtn_Click(object sender, EventArgs e)
        {
            UserPanel userpnl = new UserPanel();
            userpnl.Show();
            this.Hide();
        }
    }
}
