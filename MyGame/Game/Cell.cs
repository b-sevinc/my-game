using System.Drawing;
using System.Windows.Forms;

namespace MyGame.Game
{
    public class Cell : Label {
        public Point Point { get; set; }
        public Token Token { get; set; }
    }
}