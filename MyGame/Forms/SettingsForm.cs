using System;
using System.Windows.Forms;

namespace MyGame.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void radiobuttonCustom_CheckedChanged(object sender, EventArgs e)
        {
            groupboxCustomSize.Enabled = radiobuttonCustom.Checked;
            
            if (!groupboxCustomSize.Enabled)
            {
                textboxLength.Text = "";
                textboxWidth.Text = "";
            }
        }

        private void buttonCancelSettings_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}