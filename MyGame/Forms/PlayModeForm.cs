using System;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class PlayModeForm : Form
    {
        private readonly User _user;
        public PlayModeForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void buttonSingle_Click(object sender, EventArgs e)
        {
            Close();
            Engine.CurrentUser = _user;
            var gameForm = new GameForm();
            gameForm.Show();
        }

        private void buttonHost_Click(object sender, EventArgs e)
        {
            buttonSingle.Hide();
            buttonHost.Hide();
            buttonJoin.Hide();
            
            // TODO: Display credentials
        }


        private void buttonJoin_Click(object sender, EventArgs e)
        {
            buttonSingle.Hide();
            buttonHost.Hide();
            buttonJoin.Hide();
            
            // TODO: Enter Credentials
        }
    }
}