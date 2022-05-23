using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;
using MyGame.Properties;

namespace MyGame.Forms
{
    public partial class LoginForm : Form
    {
        private List<User> _userList = SqliteDataAccess.LoadUsers();
        
        public LoginForm()
        {
            InitializeComponent();
            usernameMaskedTextbox.Text = Settings.Default["LastUsername"].ToString();
        }

        private static void UserLogin(User user)
        {
            Engine.CurrentUser = user;
            var gameForm = new GameForm();
            gameForm.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            _userList = SqliteDataAccess.LoadUsers();
            if (_userList.All(user => user.Username != usernameMaskedTextbox.Text || 
                                      user.Password != Engine.ToSha256(passwordTextbox.Text)))
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            var loggedInUser = _userList.Find(user =>
                user.Username == usernameMaskedTextbox.Text && user.Password == Engine.ToSha256(passwordTextbox.Text));
            UserLogin(loggedInUser);
            Settings.Default["LastUsername"] = loggedInUser.Username;
            Hide();
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            passwordTextbox.SelectAll();
            passwordTextbox.Focus();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<RegisterForm>().Any()) return;
            var registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void usernameMaskedTextbox_Enter(object sender, EventArgs e)
        {
            usernameMaskedTextbox.SelectAll();
            usernameMaskedTextbox.Focus();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            passwordTextbox.PasswordChar = passwordTextbox.PasswordChar == '*' ? '\0' : '*';
        }
    }
}