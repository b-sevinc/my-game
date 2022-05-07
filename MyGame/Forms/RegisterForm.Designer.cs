using System.ComponentModel;

namespace MyGame.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxFullname = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNo = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxPassword2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(155, 26);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(250, 26);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(155, 58);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(250, 26);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxFullname
            // 
            this.textBoxFullname.Location = new System.Drawing.Point(155, 127);
            this.textBoxFullname.Name = "textBoxFullname";
            this.textBoxFullname.Size = new System.Drawing.Size(250, 26);
            this.textBoxFullname.TabIndex = 3;
            // 
            // textBoxPhoneNo
            // 
            this.textBoxPhoneNo.Location = new System.Drawing.Point(155, 159);
            this.textBoxPhoneNo.Name = "textBoxPhoneNo";
            this.textBoxPhoneNo.Size = new System.Drawing.Size(250, 26);
            this.textBoxPhoneNo.TabIndex = 4;
            this.textBoxPhoneNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhoneNo_KeyPress);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(155, 289);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(250, 63);
            this.textBoxAddress.TabIndex = 8;
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(155, 225);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(250, 26);
            this.textBoxCountry.TabIndex = 6;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(155, 257);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(250, 26);
            this.textBoxEmail.TabIndex = 7;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(155, 193);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(250, 26);
            this.textBoxCity.TabIndex = 5;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Enabled = false;
            this.buttonRegister.Location = new System.Drawing.Point(166, 418);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(107, 49);
            this.buttonRegister.TabIndex = 8;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.Location = new System.Drawing.Point(31, 29);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(106, 28);
            this.labelUsername.TabIndex = 9;
            this.labelUsername.Text = "Username*:\r\n";
            // 
            // labelPassword
            // 
            this.labelPassword.Location = new System.Drawing.Point(31, 61);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(106, 28);
            this.labelPassword.TabIndex = 10;
            this.labelPassword.Text = "Password*:\r\n";
            // 
            // labelFullName
            // 
            this.labelFullName.Location = new System.Drawing.Point(31, 130);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(106, 28);
            this.labelFullName.TabIndex = 11;
            this.labelFullName.Text = "Full Name:\r\n";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.Location = new System.Drawing.Point(31, 162);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(123, 27);
            this.labelPhoneNumber.TabIndex = 12;
            this.labelPhoneNumber.Text = "Phone Number:\r\n";
            // 
            // labelAddress
            // 
            this.labelAddress.Location = new System.Drawing.Point(31, 292);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(118, 28);
            this.labelAddress.TabIndex = 13;
            this.labelAddress.Text = "Address:\r\n";
            // 
            // labelCity
            // 
            this.labelCity.Location = new System.Drawing.Point(31, 196);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(118, 28);
            this.labelCity.TabIndex = 14;
            this.labelCity.Text = "City:\r\n";
            // 
            // labelCountry
            // 
            this.labelCountry.Location = new System.Drawing.Point(31, 228);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(118, 28);
            this.labelCountry.TabIndex = 15;
            this.labelCountry.Text = "Country:\r\n";
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(31, 260);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(118, 28);
            this.labelEmail.TabIndex = 16;
            this.labelEmail.Text = "Email:\r\n";
            // 
            // textBoxPassword2
            // 
            this.textBoxPassword2.Location = new System.Drawing.Point(155, 93);
            this.textBoxPassword2.Name = "textBoxPassword2";
            this.textBoxPassword2.Size = new System.Drawing.Size(250, 26);
            this.textBoxPassword2.TabIndex = 2;
            this.textBoxPassword2.TextChanged += new System.EventHandler(this.textBoxPassword2_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 96);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(106, 28);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password*:\r\n";
            // 
            // labelWarning
            // 
            this.labelWarning.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelWarning.Location = new System.Drawing.Point(31, 376);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(373, 26);
            this.labelWarning.TabIndex = 18;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 479);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassword2);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxPhoneNo);
            this.Controls.Add(this.textBoxFullname);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private System.Windows.Forms.Label labelWarning;

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPassword2;

        private System.Windows.Forms.Label labelCountry;

        private System.Windows.Forms.Label labelFullName;

        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelUsername;

        private System.Windows.Forms.TextBox textBoxPhoneNo;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxCity;

        private System.Windows.Forms.TextBox textBoxFullname;

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;

        #endregion
    }
}