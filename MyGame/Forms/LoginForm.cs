using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class LoginForm : Form
    {
        private List<User> _userList = SqliteDataAccess.LoadUsers();
        
        public LoginForm()
        {
            InitializeComponent();
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
            if (_userList.All(user => user.Username != usernameTextbox.Text || 
                                      user.Password != Engine.ToSha256(passwordTextbox.Text)))
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            UserLogin(_userList.Find(user => user.Username == usernameTextbox.Text && user.Password == Engine.ToSha256(passwordTextbox.Text)));
            Hide();
        }

        private void usernameTextBox_Enter(object sender, EventArgs e)
        {
            usernameTextbox.SelectAll();
            usernameTextbox.Focus();
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
    }
}