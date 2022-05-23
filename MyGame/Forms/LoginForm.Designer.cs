namespace MyGame.Forms
{
    partial class LoginForm
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
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.usernameMaskedTextbox = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(204, 125);
            this.passwordTextbox.MaxLength = 20;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(204, 26);
            this.passwordTextbox.TabIndex = 1;
            this.passwordTextbox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(77, 197);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(146, 38);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(77, 66);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(92, 26);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(77, 125);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(92, 26);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(262, 197);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(146, 38);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // usernameMaskedTextbox
            // 
            this.usernameMaskedTextbox.Location = new System.Drawing.Point(204, 63);
            this.usernameMaskedTextbox.Mask = "L???????????";
            this.usernameMaskedTextbox.Name = "usernameMaskedTextbox";
            this.usernameMaskedTextbox.PromptChar = ' ';
            this.usernameMaskedTextbox.Size = new System.Drawing.Size(203, 26);
            this.usernameMaskedTextbox.TabIndex = 0;
            this.usernameMaskedTextbox.Enter += new System.EventHandler(this.usernameMaskedTextbox_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(414, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "👁";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 345);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usernameMaskedTextbox);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.MaskedTextBox usernameMaskedTextbox;

        private System.Windows.Forms.Button buttonRegister;

        private System.Windows.Forms.Button loginButton;

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;

        private System.Windows.Forms.TextBox passwordTextbox;

        #endregion
    }
}