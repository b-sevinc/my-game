using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;
using MyGame.Properties;

namespace MyGame.Forms
{
    public partial class GameForm : Form
    {
        private Panel[,] _boardPanels;
        
        public GameForm()
        {
            InitializeComponent();
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
            const int tileSize = 45;
            int gridX = (int)Settings.Default["GridX"];
            int gridY = (int)Settings.Default["GridY"];
            ConstructBoard(tileSize, gridX, gridY);
            
            Width = gridX * tileSize + 6;
            Height = gridY * tileSize + adminPanelToolStripMenuItem.Size.Height + 29;
        }

        private void ConstructBoard(int tileSize, int gridX, int gridY)
        {
            // _chessBoardPanels = new Panel[gridX, gridY];
            _boardPanels = new Panel[gridX, gridY];
            for (var i = 0; i < gridX; i++)
            {
                for (var j = 0; j < gridY; j++)
                {
                    // create new Panel control which will be one 
                    // chess board tile
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(x: tileSize * i, tileSize * j + adminPanelToolStripMenuItem.Size.Height)
                    };
 
                    _boardPanels[i, j] = newPanel;  // add to our 2d array of panels for future use
                    Controls.Add(newPanel);  // add to Form's Controls so that they show up
                    newPanel.BackColor = (i + j) % 2 == 0 ? Color.Tan : Color.Moccasin;  // color the backgrounds
                }
            }
        }
    }
}