using System;
using System.Windows.Forms;

namespace MyGame.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == "admin" && passwordTextbox.Text == "admin" 
                || usernameTextbox.Text == "user" && passwordTextbox.Text == "user")
            {
                Hide();
                GameForm gameForm = new GameForm();
                gameForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void usernameTextbox_Enter(object sender, EventArgs e)
        {
            usernameTextbox.SelectAll();
            usernameTextbox.Focus();
        }

        private void passwordTextbox_Enter(object sender, EventArgs e)
        {
            passwordTextbox.SelectAll();
            passwordTextbox.Focus();
        }
    }
}