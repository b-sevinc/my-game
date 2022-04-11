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
                return (int)Enums.Difficulty.Easy;
            }
            if (radioButtonNormal.Checked)
            {
                return (int)Enums.Difficulty.Normal;
            }
            if (radiobuttonHard.Checked)
            {
                return (int)Enums.Difficulty.Hard;
            }

            return (int)Enums.Difficulty.Custom;
        }

        private void SetMarkedDifficulty(int diff)
        {
            switch (diff)
            {
                case (int)Enums.Difficulty.Easy:
                    radiobuttonEasy.Checked = true;
                    break;
                case (int)Enums.Difficulty.Normal:
                    radioButtonNormal.Checked = true;
                    break;
                case (int)Enums.Difficulty.Hard:
                    radiobuttonHard.Checked = true;
                    break;
                default:
                    radiobuttonCustom.Checked = true;
                    break;
            }
        }
    }
}