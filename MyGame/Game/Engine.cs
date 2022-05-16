using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGame.Forms;
using MyGame.Properties;

namespace MyGame.Game
{
    public class Engine
    {
        private static Engine _instance;
        public static User CurrentUser { get; set; }
        public static Engine Instance => _instance ?? (_instance = new Engine());
        public static Label Score { get; set; }

        private static Cell _selectedCell;
        public static bool CanPlay = true;
        private static readonly Random Random = new Random();
        public static Cell[,] BoardCells;
        private static int _fullCellCount;
        public static int CellX = (int)Settings.Default["GridX"];
        public static int CellY = (int)Settings.Default["GridY"];
        private static int _score;

        private Engine()
        {
        }

        public static string ToSha256(string s)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                var sb = new StringBuilder();
                foreach (var t in bytes)
                {
                    sb.Append(t.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static bool IsPasswordCorrect(string s)
        {
            if (CurrentUser is null) return false;
            return CurrentUser.Password == ToSha256(s);
        }

        public static void EndGame(bool restart = false)
        {
            if (_score > CurrentUser.HighestScore)
            {
                CurrentUser.HighestScore = _score;
                SqliteDataAccess.UpdateUser(CurrentUser);
            }

            if (restart)
            {
                BoardCells = null;
                CellX = (int) Settings.Default["GridX"];
                CellY = (int) Settings.Default["GridY"];
                Application.OpenForms.OfType<GameForm>().First().Close();
                var gameForm = new GameForm();
                gameForm.Show();
                return;
            }

            MessageBox.Show("Game Over.\nScore:" + _score);
            Application.Exit();
        }

        public static async void SelectCell(Cell panel)
        {
            UnselectCell(panel);

            if (_selectedCell == null)
            {
                _selectedCell = panel;
                _selectedCell.BackgroundImage = Resources.frame;
                return;
            }
            
            _selectedCell.BackgroundImage = _selectedCell.BackgroundImage is null ? Resources.frame : null;
            await MoveToken(_selectedCell, panel);
            _selectedCell = null;
        }

        private static void UnselectCell(Cell panel)
        {
            if (panel == null) return;
            if (_selectedCell != panel) return;
            _selectedCell.BackgroundImage = null;
            _selectedCell = null;
        }

        private static async Task MoveToken(Cell source, Cell target)
        {
            var isTargetFree = target.Token is null;
            if (!isTargetFree) return;
            
            var path = new List<Point>();
            SearchPath(source, target, path);
            for (var i = path.Count - 1; i > 0 ; i--)
            {
                CanPlay = false;
                await Step(path[i], path[i-1]);
            }

            if (path.Count == 0) return;
            CanPlay = true;
            
            UpdateGrid();
            
            if (!CheckForScore(target))
            {
                AddThreeToken();
            }
        }

        public static void AddThreeToken()
        {
            if (CellX * CellY <= _fullCellCount + 3)
            {
                EndGame();
            }
            
            for (int i = 0; i < 3; i++)
            {
                var point = FindEmptyCell();
                var token = new Token
                {
                    Color = RollColor(),
                    Shape = RollShape(),
                };
                
                BoardCells[point.X, point.Y].Token = token;
                CheckForScore(BoardCells[point.X, point.Y]);
                _fullCellCount++;
            }
            UpdateGrid();
        }

        private static bool CheckForScore(Cell target)
        {
            var horizontalCellSet = SearchRowForward(target, new HashSet<Cell>{target});
            horizontalCellSet.UnionWith(SearchRowBackward(target, horizontalCellSet));
            bool horizontalScore = horizontalCellSet.Count >= 5;
            
            var verticalCellSet = SearchColumnUpward(target, new HashSet<Cell>{target});
            verticalCellSet.UnionWith(SearchColumnDownward(target, verticalCellSet));
            bool verticalScore = verticalCellSet.Count >= 5;

            int totalCount = 0;
            
            if (!horizontalScore && !verticalScore) return false;
            
            foreach (var gameCell in horizontalCellSet.Select(cell => BoardCells[cell.Point.X, cell.Point.Y]))
            {
                gameCell.Token = null;
                totalCount += 1;
            }
            
            foreach (var gameCell in verticalCellSet.Select(cell => BoardCells[cell.Point.X, cell.Point.Y]))
            {
                if (gameCell.Token is null) continue;
                gameCell.Token = null;
                totalCount += 1;
            }

            _fullCellCount -= totalCount;
            _score += totalCount * GetDifficultyScore();
            UpdateGrid();
            var player = new SoundPlayer(@"C:\Users\ovid\Desktop\oop-lab\lab-demo\my-game\MyGame\Properties\Resources\score.wav");
            player.Play();
            return true;
        }

        private static Point FindEmptyCell()
        {
            while (true)
            {
                int x = Random.Next(CellX);
                int y = Random.Next(CellY);
                if (BoardCells[x, y].Token is null)
                {
                    return new Point(x, y);
                }
            }
        }

        private static void UpdateGrid()
        {
            for (var i = 0; i < CellX; i++)
            {
                for (var j = 0; j < CellY; j++)
                {
                    var cell = BoardCells[i, j];
                    var token = cell.Token;

                    if (token is null)
                    {
                        cell.Text = null;
                        cell.ForeColor = Color.Black;
                        continue;
                    }
                    
                    var color = token.Color;
                    switch (token.Shape)
                    {
                        case Enums.Shape.Circle:
                            cell.Text = "●";
                            break;
                        case Enums.Shape.Square:
                            cell.Text = "■";
                            break;
                        case Enums.Shape.Triangle:
                            cell.Text = "▲";
                            break;
                    }

                    cell.ForeColor = color;
                }
            }

            Score.Text = _score.ToString();
        }

        private static HashSet<Cell> SearchRowForward(Cell currentCell, HashSet<Cell> cells)
        {
            var currentToken = currentCell.Token;
            if (currentCell.Point.X + 1 >= CellX || currentToken is null) return cells;
            var nextCell = BoardCells[currentCell.Point.X + 1, currentCell.Point.Y];
            var nextToken = nextCell.Token;
            if (nextCell.Token is null) return cells;
            if (!Equals(currentToken.Shape, nextToken.Shape) || currentToken.Color != nextToken.Color) return cells;

            cells.Add(nextCell);
            return SearchRowForward(nextCell, cells);
        }
        
        private static HashSet<Cell> SearchRowBackward(Cell currentCell, HashSet<Cell> cells)
        {
            var currentToken = currentCell.Token;
            if (currentCell.Point.X < 1 || currentToken is null) return cells;
            var previousCell = BoardCells[currentCell.Point.X - 1, currentCell.Point.Y];
            var previousToken = previousCell.Token;
            if (previousCell.Token is null) return cells;
            if (!Equals(currentToken.Shape, previousToken.Shape) || currentToken.Color != previousToken.Color) return cells;

            cells.Add(previousCell);
            return SearchRowBackward(previousCell, cells);
        }
        
        private static HashSet<Cell> SearchColumnUpward(Cell currentCell, HashSet<Cell> cells)
        {
            var currentToken = currentCell.Token;
            if (currentCell.Point.Y + 1 >= CellY || currentToken is null) return cells;
            var upCell = BoardCells[currentCell.Point.X, currentCell.Point.Y + 1];
            var upToken = upCell.Token;
            if (upCell.Token is null) return cells;
            if (!Equals(currentToken.Shape, upToken.Shape) || currentToken.Color != upToken.Color) return cells;

            cells.Add(upCell);
            return SearchColumnUpward(upCell, cells);
        }
        
        private static HashSet<Cell> SearchColumnDownward(Cell currentCell, HashSet<Cell> cells)
        {
            var currentToken = currentCell.Token;
            if (currentCell.Point.Y < 1 || currentToken is null) return cells;
            var downCell = BoardCells[currentCell.Point.X, currentCell.Point.Y - 1];
            var downToken = downCell.Token;
            if (downCell.Token is null) return cells;
            if (!Equals(currentToken.Shape, downToken.Shape) || currentToken.Color != downToken.Color) return cells;

            cells.Add(downCell);
            return SearchColumnDownward(downCell, cells);
        }

        // A* path-finding implementation inspired by dotnetcoretutorials.com/author/admin
        private static void SearchPath(Cell currentCell, Cell targetCell, List<Point> path)
        {
            var start = new Grid
            {
                X = currentCell.Point.X,
                Y = currentCell.Point.Y
            };
            var finish = new Grid
            {
                X = targetCell.Point.X,
                Y = targetCell.Point.Y
            };

            start.SetDistance(finish.X, finish.Y);
            var activeTiles = new List<Grid> {start};
            var visitedTiles = new List<Grid>();
            
            while(activeTiles.Any())
            {
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();
                if(checkTile.X == finish.X && checkTile.Y == finish.Y)
                {
                    var tile = checkTile;
                    while(true)
                    {
                        var p = new Point(tile.X, tile.Y);
                        path.Add(p);
                        tile = tile.Parent;
                        if (tile != null) continue;
                        return;
                    }
                }
                
                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);
                var walkableTiles = Grid.GetWalkableTiles(checkTile, finish);
                foreach (var walkableTile in walkableTiles.Where(walkableTile => !visitedTiles.Any(t => t.X == walkableTile.X && t.Y == walkableTile.Y)))
                {
                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if(activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if (existingTile.CostDistance <= checkTile.CostDistance) continue;
                        activeTiles.Remove(existingTile);
                        activeTiles.Add(walkableTile);
                    }
                    else
                    {
                        activeTiles.Add(walkableTile);  //We've never seen this tile before so add it to the list. 
                    }
                }
            }
        }

        private static async Task Step(Point currentPoint, Point nextPoint)
        {
            var token = BoardCells[currentPoint.X, currentPoint.Y].Token;
            BoardCells[currentPoint.X, currentPoint.Y].Token = null;
            BoardCells[nextPoint.X, nextPoint.Y].Token = token;
            await Task.Delay(500);
            var player = new SoundPlayer(@"C:\Users\ovid\Desktop\oop-lab\lab-demo\my-game\MyGame\Properties\Resources\step.wav");
            player.Play();
            UpdateGrid();
        }

        private static Color RollColor()
        {
            bool isRed = (bool) Settings.Default["Red"];
            bool isBlue = (bool) Settings.Default["Blue"];
            bool isGreen = (bool) Settings.Default["Green"];
            var possibleColors = new List<Color>();
            if (isRed) possibleColors.Add(Color.Red);
            if (isBlue) possibleColors.Add(Color.Blue);
            if (isGreen) possibleColors.Add(Color.Green);
            return possibleColors[Random.Next(possibleColors.Count)];
        }
        
        private static Enum RollShape()
        {
            var isCircle = (bool) Settings.Default["Circle"];
            var isSquare = (bool) Settings.Default["Square"];
            var isTriangle = (bool) Settings.Default["Triangle"];
            var possibleShapes = new List<Enum>();
            if (isCircle) possibleShapes.Add(Enums.Shape.Circle);
            if (isSquare) possibleShapes.Add(Enums.Shape.Square);
            if (isTriangle) possibleShapes.Add(Enums.Shape.Triangle);
            return possibleShapes[Random.Next(possibleShapes.Count)];
        }
        
        private static int GetDifficultyScore()
        {
            switch (Settings.Default["Difficulty"])
            {
                case (int)Enums.Difficulty.Easy:
                    return 1;
                case (int)Enums.Difficulty.Normal:
                    return 3;
                case (int)Enums.Difficulty.Hard:
                    return 5;
                default:
                    return 2;
            }
        }
    }
}