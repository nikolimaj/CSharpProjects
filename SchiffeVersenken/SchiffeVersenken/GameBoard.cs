using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken
{
    internal abstract class IGameBoard<GameTileType> where GameTileType : class, IGameTile
    {
        public int rows { get { return grid.GetLength(0); } }
        public int columns { get { return grid.GetLength(1); } }

        protected GameTileType[,] grid { get; set; }
        public HashSet<Ship> ships { get; protected set; }

        public IGameBoard()
        {
            ships = new HashSet<Ship>();
        }

        public IGameBoard(TableLayoutPanel gui) : this()
        {
            int rows = gui.RowCount;
            int columns = gui.ColumnCount;

            grid = new GameTileType[rows, columns];

            // initialize grid with empty cells
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    grid[r, c] = gui.GetControlFromPosition(r, c) as GameTileType;
                }
            }
        }

        public void Reset()
        {
            ships.Clear();

            foreach (IGameTile tile in grid)
            {
                tile.Reset();
            }
        }



    }
}
