using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGame.Game
{
    public class Grid
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int CostDistance => Cost + Distance;
        public Grid Parent { get; set; }
        public void SetDistance(int targetX, int targetY)
        {
            Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
        public static List<Grid> GetWalkableTiles(Grid currentTile, Grid targetTile)
        {
            var possibleTiles = new List<Grid>()
            {
                new Grid { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Grid { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
                new Grid { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Grid { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            };
            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));
            return possibleTiles
                .Where(tile => tile.X >= 0 && tile.X < Engine.CellX)
                .Where(tile => tile.Y >= 0 && tile.Y < Engine.CellY)
                .Where(tile => Engine.BoardCells[tile.X, tile.Y].Token is null || 
                               Engine.BoardCells[tile.X, tile.Y].Point.X == targetTile.X &&
                               Engine.BoardCells[tile.X, tile.Y].Point.Y == targetTile.Y)
                .ToList();
        }
    }
}