using System;
using System.Windows.Forms;

namespace MyGame.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            SetMarkedDifficulty((int)Properties.Settings.Default["Difficulty"]);
            SetMarkedshape((int)Properties.Settings.Default["Shape"]);
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

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Difficulty"] = GetMarkedDifficulty();
            Properties.Settings.Default["Shape"] = GetMarkedShape();
            Properties.Settings.Default.Save();
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

        private int GetMarkedShape()
        {
            if (radiobuttonCircle.Checked)
            {
                return 0;
            }

            if (radiobuttonSquare.Checked)
            {
                return 1;
            }

            return 2;
        }

        private void SetMarkedshape(int shape)
        {
            switch (shape)
            {
                case 0:
                    radiobuttonCircle.Checked = true;
                    break;
                case 1:
                    radiobuttonSquare.Checked = true;
                    break;
                default:
                    radiobuttonTriangle.Checked = true;
                    break;
            }
        }
    }
}