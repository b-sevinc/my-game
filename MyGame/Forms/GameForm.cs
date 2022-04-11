using System;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }
        
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SettingsForm>().Any()) return;
            var settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AccountForm>().Any()) return;
            var accountForm = new AccountForm();
            accountForm.Show();
        }

        private void adminPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AdminForm>().Any()) return;
            var adminForm = new AdminForm();
            adminForm.Show();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            adminPanelToolStripMenuItem.Visible = Engine.CurrentUser?.UserType == (int)Enums.UserType.Admin;
        }
    }
}