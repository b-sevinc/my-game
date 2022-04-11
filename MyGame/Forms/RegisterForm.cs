using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = textBoxUsername.Text,
                Password = Engine.ToSha256(textBoxPassword.Text),
                UserType = 0,
                FullName = textBoxFullname.Text,
                Address = textBoxAddress.Text,
                PhoneNumber = textBoxPhoneNo.Text,
                City = textBoxCity.Text,
                Country = textBoxCountry.Text,
                Email = textBoxEmail.Text,
            };
            
            Engine.AddUser(user);
            CleanRegisterForm();
        }

        private bool IsPasswordValid()
        {
            return textBoxPassword.Text == textBoxPassword2.Text;
        }

        private bool IsUsernameValid()
        {
            List<User> userList = Engine.ReadUsersJson();
            return userList.All(user => user.Username != textBoxUsername.Text);
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            CanRegister();
            labelWarning.Text = !IsUsernameValid() ? "Name already in use" : "";
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CanRegister();
            labelWarning.Text = !IsPasswordValid() ? "Passwords do not match" : "";
        }
        
        private void textBoxPassword2_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword_TextChanged(sender, e);
        }

        private void CanRegister()
        {
            buttonRegister.Enabled = !(textBoxUsername.Text == ""
                                       || textBoxPassword.Text == "" 
                                       || textBoxPassword2.Text == "" 
                                       || !IsPasswordValid()
                                       || !IsUsernameValid());
        }

        private void CleanRegisterForm()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            textBoxPassword2.Text = "";
            textBoxFullname.Text = "";
            textBoxAddress.Text = "";
            textBoxPhoneNo.Text = "";
            textBoxCity.Text = "";
            textBoxCountry.Text = "";
            textBoxEmail.Text = "";
            CanRegister();
        }

        private void textBoxPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}