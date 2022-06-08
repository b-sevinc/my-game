using System;
using System.Windows.Forms;
using MyGame.Game;

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

            textboxLength.Text = settings["GridX"].ToString();
            textboxWidth.Text = settings["GridY"].ToString();
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
            int shapeCount = 0;
            shapeCount += checkBoxCircle.Checked ? 1 : 0;
            shapeCount += checkBoxSquare.Checked ? 1 : 0;
            shapeCount += checkBoxTriangle.Checked ? 1 : 0;
            if (shapeCount < 1)
            {
                MessageBox.Show("Choose at least one shape.");
                return;
            }

            int colorCount = 0;
            colorCount += checkboxRed.Checked ? 1 : 0;
            colorCount += checkboxGreen.Checked ? 1 : 0;
            colorCount += checkboxBlue.Checked ? 1 : 0;
            if (colorCount < 1)
            {
                MessageBox.Show("Choose at least one color.");
                return;
            }

            if (colorCount * shapeCount <= 1)
            {
                MessageBox.Show("Choose at least one multiple color or shape.");
                return;
            }

            var gridX = int.Parse(textboxLength.Text);
            var gridY = int.Parse(textboxWidth.Text);

            if (gridX < 5 || gridY < 5 || gridX > 19 || gridY > 19)
            {
                MessageBox.Show("Grid sizes should be 5-19.");
                return;
            }
            
            Properties.Settings.Default["Difficulty"] = GetMarkedDifficulty();
            Properties.Settings.Default["Circle"] = checkBoxCircle.Checked;
            Properties.Settings.Default["Square"] = checkBoxSquare.Checked;
            Properties.Settings.Default["Triangle"] = checkBoxTriangle.Checked;
            Properties.Settings.Default["Red"] = checkboxRed.Checked;
            Properties.Settings.Default["Green"] = checkboxGreen.Checked;
            Properties.Settings.Default["Blue"] = checkboxBlue.Checked;
            Properties.Settings.Default["GridX"] = gridX;
            Properties.Settings.Default["GridY"] = gridY;
            Properties.Settings.Default.Save();
            Close();
            Engine.RestartGame(true);
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

        private void radiobuttonEasy_CheckedChanged(object sender, EventArgs e)
        {
            textboxLength.Text = "15";
            textboxWidth.Text = "15";
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            textboxLength.Text = "9";
            textboxWidth.Text = "9";
        }

        private void radiobuttonHard_CheckedChanged(object sender, EventArgs e)
        {
            textboxLength.Text = "6";
            textboxWidth.Text = "6";
        }
    }
}