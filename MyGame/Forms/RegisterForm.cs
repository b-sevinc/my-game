using System;
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
            var user = new User
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
            
            SqliteDataAccess.SaveUser(user);
            Close();
        }

        private bool IsPasswordValid()
        {
            return textBoxPassword.Text == textBoxPassword2.Text;
        }

        private bool IsUsernameValid()
        {
            var userList = SqliteDataAccess.LoadUsers();
            return userList.All(user => user.Username != textBoxUsername.Text);
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            CheckRegister();
            labelWarning.Text = !IsUsernameValid() ? "Name already in use" : null;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckRegister();
            labelWarning.Text = !IsPasswordValid() ? "Passwords do not match" : null;
        }
        
        private void textBoxPassword2_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword_TextChanged(sender, e);
        }

        private void CheckRegister()
        {
            buttonRegister.Enabled = !(textBoxUsername.Text is null
                                       || textBoxPassword.Text is null 
                                       || textBoxPassword2.Text is null 
                                       || !IsPasswordValid()
                                       || !IsUsernameValid());
        }

        private void textBoxPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}