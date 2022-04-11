using System;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            var user = Engine.CurrentUser;
            
            textBoxUsername.Text = user.Username;
            textBoxFullname.Text = user.FullName;
            textBoxPhoneNumber.Text = user.PhoneNumber;
            textBoxAddress.Text = user.Address;
            textBoxCity.Text = user.City;
            textBoxCountry.Text = user.Country;
            textBoxEmail.Text = user.Email;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!Engine.IsPasswordCorrect(textBoxConfirm.Text))
            {
                MessageBox.Show("Wrong password.");
                return;
            }

            var user = Engine.CurrentUser;
            
            user.Address = textBoxAddress.Text;
            user.City = textBoxCity.Text;
            user.Country = textBoxCountry.Text;
            user.Email = textBoxEmail.Text;
            user.PhoneNumber = textBoxPhoneNumber.Text;
            user.FullName = textBoxFullname.Text;
            
            if (textBoxPassword.Text == textBoxPassword2.Text && textBoxPassword.Text != "" && textBoxPassword2.Text != "")
            {
                user.Password = Engine.ToSha256(textBoxPassword.Text);
            }
            
            Engine.UpdateUser(user);
            Close();
            MessageBox.Show("Successfully edited account information.");
        }
    }
}