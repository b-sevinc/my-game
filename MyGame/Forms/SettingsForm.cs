using System;
using System.Windows.Forms;

namespace MyGame.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            var settings = Properties.Settings.Default;
            InitializeComponent();
            SetMarkedDifficulty((int)settings["Difficulty"]);
            checkBoxCircle.Checked = (bool) settings["Circle"];
            checkBoxSquare.Checked = (bool) settings["Square"];
            checkBoxTriangle.Checked = (bool) settings["Triangle"];
            checkboxRed.Checked = (bool) settings["Red"];
            checkboxGreen.Checked = (bool) settings["Green"];
            checkboxBlue.Checked = (bool) settings["Blue"];

            if (radiobuttonCustom.Checked)
            {
                // TODO: Save custom dimensions
            }
        }

        private void radiobuttonCustom_CheckedChanged(object sender, EventArgs e)
        {
            groupboxCustomSize.Enabled = radiobuttonCustom.Checked;

            if (groupboxCustomSize.Enabled) return;
            
            textboxLength.Text = "";
            textboxWidth.Text = "";
        }

        private void buttonCancelSettings_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Difficulty"] = GetMarkedDifficulty();
            Properties.Settings.Default["Circle"] = checkBoxCircle.Checked;
            Properties.Settings.Default["Square"] = checkBoxSquare.Checked;
            Properties.Settings.Default["Triangle"] = checkBoxTriangle.Checked;
            Properties.Settings.Default["Red"] = checkboxRed.Checked;
            Properties.Settings.Default["Green"] = checkboxGreen.Checked;
            Properties.Settings.Default["Blue"] = checkboxBlue.Checked;
            Properties.Settings.Default.Save();
            Hide();
        }

        private int GetMarkedDifficulty()
        {
            if (radiobuttonEasy.Checked)
            {
                return 0;
            }
            if (radioButtonNormal.Checked)
            {
                return 1;
            }
            if (radiobuttonHard.Checked)
            {
                return 2;
            }

            return 9;
        }

        private void SetMarkedDifficulty(int diff)
        {
            switch (diff)
            {
                case 0:
                    radiobuttonEasy.Checked = true;
                    break;
                case 1:
                    radioButtonNormal.Checked = true;
                    break;
                case 2:
                    radiobuttonHard.Checked = true;
                    break;
                default:
                    radiobuttonCustom.Checked = true;
                    break;
            }
        }
    }
}