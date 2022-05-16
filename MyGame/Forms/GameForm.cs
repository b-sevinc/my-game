using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyGame.Game;

namespace MyGame.Forms
{
    public partial class GameForm : Form
    {
        private const int TileSize = 45;
        private readonly int _cellX = (int)Properties.Settings.Default["GridX"];
        private readonly int _cellY = (int)Properties.Settings.Default["GridY"];

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
            ConstructBoard(TileSize, _cellX, _cellY);
            Engine.AddThreeToken();
        }

        private void NewPanel_MouseClick(object sender, EventArgs e)
        {
            if (!Engine.CanPlay) return;
            var panel = sender as Cell;
            Engine.SelectCell(panel);
        }

        private void ConstructBoard(int size, int x, int y)
        {
            Width = _cellX * TileSize + 50;
            Height = _cellY * TileSize + adminPanelToolStripMenuItem.Size.Height + 40;
            
            Engine.BoardCells = new Cell[x, y];
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    var newCell = new Cell
                    {
                        Size = new Size(size, size),
                        Location = new Point(x: size * i, size * j + adminPanelToolStripMenuItem.Size.Height),
                        Point = new Point(i, j),
                        Font = new Font(FontFamily.GenericSansSerif, 20),
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
 
                    Engine.BoardCells[i, j] = newCell;  // add to our 2d array of panels for future use
                    Controls.Add(newCell);  // add to Form's Controls so that they show up
                    newCell.BackColor = (i + j) % 2 == 0 ? Color.Tan : Color.Moccasin;
                    newCell.MouseClick += NewPanel_MouseClick;
                }
            }
            
            var score = new Label
            {
                Size = new Size(20, 20),
                Location = new Point(Width - 36, 20),
                Text = "0",
            };

            Engine.Score = score;
            Controls.Add(score);
            
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Engine.EndGame();
        }
    }
}