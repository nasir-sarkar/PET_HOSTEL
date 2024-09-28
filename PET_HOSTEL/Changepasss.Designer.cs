namespace PET_HOSTEL
{
    partial class Changepasss
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.npass = new System.Windows.Forms.TextBox();
            this.cpass = new System.Windows.Forms.TextBox();
            this.updt = new System.Windows.Forms.Button();
            this.sp = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm password";
            // 
            // npass
            // 
            this.npass.Location = new System.Drawing.Point(296, 164);
            this.npass.Multiline = true;
            this.npass.Name = "npass";
            this.npass.PasswordChar = '*';
            this.npass.Size = new System.Drawing.Size(311, 36);
            this.npass.TabIndex = 2;
            // 
            // cpass
            // 
            this.cpass.Location = new System.Drawing.Point(296, 239);
            this.cpass.Multiline = true;
            this.cpass.Name = "cpass";
            this.cpass.PasswordChar = '*';
            this.cpass.Size = new System.Drawing.Size(310, 34);
            this.cpass.TabIndex = 3;
            // 
            // updt
            // 
            this.updt.BackColor = System.Drawing.Color.Turquoise;
            this.updt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updt.ForeColor = System.Drawing.Color.Transparent;
            this.updt.Location = new System.Drawing.Point(441, 346);
            this.updt.Name = "updt";
            this.updt.Size = new System.Drawing.Size(165, 47);
            this.updt.TabIndex = 4;
            this.updt.Text = "Update";
            this.updt.UseVisualStyleBackColor = false;
            this.updt.Click += new System.EventHandler(this.updt_Click);
            // 
            // sp
            // 
            this.sp.AutoSize = true;
            this.sp.Location = new System.Drawing.Point(458, 292);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(148, 24);
            this.sp.TabIndex = 5;
            this.sp.Text = "Show Password";
            this.sp.UseVisualStyleBackColor = true;
            this.sp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 70);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(275, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Change Password";
            // 
            // Changepasss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.updt);
            this.Controls.Add(this.cpass);
            this.Controls.Add(this.npass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Changepasss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changepasss";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox npass;
        private System.Windows.Forms.TextBox cpass;
        private System.Windows.Forms.Button updt;
        private System.Windows.Forms.CheckBox sp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}