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

            textboxLength.Text = settings["CustomX"].ToString();
            textboxWidth.Text = settings["CustomY"].ToString();
        }

        private void radiobuttonCustom_CheckedChanged(object sender, EventArgs e)
        {
            groupboxCustomSize.Enabled = radiobuttonCustom.Checked;
        }

        private void buttonCancelSettings_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            if (!checkBoxCircle.Checked && !checkBoxSquare.Checked && !checkBoxTriangle.Checked)
            {
                MessageBox.Show("Choose at least one shape.");
                return;
            }

            if (!checkboxRed.Checked && !checkboxGreen.Checked && !checkboxBlue.Checked)
            {
                MessageBox.Show("Choose at least one color.");
                return;
            }
            
            Properties.Settings.Default["Difficulty"] = GetMarkedDifficulty();
            Properties.Settings.Default["Circle"] = checkBoxCircle.Checked;
            Properties.Settings.Default["Square"] = checkBoxSquare.Checked;
            Properties.Settings.Default["Triangle"] = checkBoxTriangle.Checked;
            Properties.Settings.Default["Red"] = checkboxRed.Checked;
            Properties.Settings.Default["Green"] = checkboxGreen.Checked;
            Properties.Settings.Default["Blue"] = checkboxBlue.Checked;
            Properties.Settings.Default["CustomX"] = int.Parse(textboxLength.Text);
            Properties.Settings.Default["CustomY"] = int.Parse(textboxWidth.Text);
            Properties.Settings.Default.Save();
            Close();
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