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
            User currentUser = Engine.CurrentUser;
            textBoxUsername.Text = currentUser.Username;
            textBoxFullname.Text = currentUser.FullName;
            textBoxPhoneNumber.Text = currentUser.PhoneNumber;
            textBoxAddress.Text = currentUser.Address;
            textBoxCity.Text = currentUser.City;
            textBoxCountry.Text = currentUser.Country;
            textBoxEmail.Text = currentUser.Email;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!Engine.IsPasswordCorrect(textBoxConfirm.Text))
            {
                MessageBox.Show("Wrong password.");
                return;
            }
            
            User currentUser = Engine.CurrentUser;
            currentUser.Address = textBoxAddress.Text;
            currentUser.City = textBoxCity.Text;
            currentUser.Country = textBoxCountry.Text;
            currentUser.Email = textBoxEmail.Text;
            currentUser.PhoneNumber = textBoxPhoneNumber.Text;
            currentUser.FullName = textBoxFullname.Text;
            
            if (textBoxPassword.Text == textBoxPassword2.Text && textBoxPassword.Text != "" && textBoxPassword2.Text != "")
            {
                currentUser.Password = Engine.ToSha256(textBoxPassword.Text);
            }
            
            Engine.UpdateUser(currentUser);
            Close();
            MessageBox.Show("Succesfully edited account information.");
        }
    }
}