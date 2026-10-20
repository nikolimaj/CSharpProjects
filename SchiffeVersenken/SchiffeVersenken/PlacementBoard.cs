using System.Windows.Forms;

namespace SchiffeVersenken
{
    internal class PlacementBoard : IGameBoard<IGameTile> 
    {
        private static Dictionary<int, int> desiredLengths = new Dictionary<int, int>
        {
            { 4, 1 },
            { 3, 2 },
            { 2, 3 },
            { 1, 4 }
        };

        public PlacementBoard(int rows, int cols):base()
        {
            grid = new IGameTile[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = new BindableGuessingTile(i, j);
                }
            }
        }

        public PlacementBoard(TableLayoutPanel gui) : base(gui)
        {
        }

        public void toggleState(int row, int col)
        {
            if (grid[row, col].isShip)
            {
                RemoveShip(row, col);
            }
            else
            {
                AddShip(row, col);
            }

        }

        public int MaxShipLength()
        {
            var occurrences = ships.Select(ship => ship.Length).GroupBy(length => length).OrderBy(group => group.Key).ToDictionary(group => group.Key, c => c.Count());

            foreach (var pair in desiredLengths)
            {
                if (!occurrences.ContainsKey(pair.Key))
                {
                    return pair.Key;
                }

                if (pair.Value > occurrences[pair.Key])
                {
                    return pair.Key;
                }
            }

            return 0;
        }

        public bool isValidShipPos(int row, int col)
        {
            if (row < 0 || row >= grid.GetLength(0) || col < 0 || col >= grid.GetLength(1))
            {
                return false;
            }

            if (grid[row, col].isShip)
            {
                return false;
            }

            List<Ship> neighbouringShips = GetNeighbouringShips(row, col);

            if (neighbouringShips.Count > 1) return false;

            if (neighbouringShips.Count == 1)
            {
                return neighbouringShips[0].IsValidPosition(grid[row, col], MaxShipLength());
            }

            return true;
        }

        protected bool AddShip(int row, int col)
        {
            if (grid[row, col].isShip)
            {
                return false;
            }

            List<Ship> neighbouringShips = GetNeighbouringShips(row, col);

            if (neighbouringShips.Count > 1) return false;

            Ship ship;
            if (neighbouringShips.Count == 1)
            {
                ship = neighbouringShips[0];
            }
            else
            {
                ship = new Ship();
                ships.Add(ship);
            }

            return ship.AddShipTile(grid[row, col], MaxShipLength());
        }

        private List<Ship> GetNeighbouringShips(int row, int col)
        {
            List<Ship> ships = new List<Ship>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int pos_x = row + x;
                    int pos_y = col + y;

                    // check if pos is valid
                    if (pos_x >= 0 && pos_x < grid.GetLength(0) && pos_y >= 0 && pos_y < grid.GetLength(1))
                    {
                        if (grid[pos_x, pos_y].isShip)
                        {
                            // check if not the same tile
                            if (x == 0 && y == 0)
                            {
                                continue;
                            }
                            IGameTile tile = grid[pos_x, pos_y];

                            ships.Add(tile.Ship);
                        }
                    }
                }
            }

            return ships;
        }

        protected bool RemoveShip(int row, int col)
        {
            List<Ship> neighbouringShips = GetNeighbouringShips(row, col);

            // ships can not be split
            if (neighbouringShips.Count > 1) return false;

            if (neighbouringShips.Count == 0)
            {
                // remove ship from set
                ships.Remove(grid[row, col].Ship);
                return true;
            }

            Ship ship = neighbouringShips[0];
            ship.RemoveShipTile(grid[row, col]);

            return true;
        }

        public bool isValid()
        {
            // check if all ships are placed

            var occurrences = ships.Select(ship => ship.Length).GroupBy(length => length).ToDictionary(length => length.Key, c => c.Count());

            foreach (var pair in desiredLengths)
            {
                if (occurrences.ContainsKey(pair.Key))
                {
                    if (pair.Value != occurrences[pair.Key])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public IGameTile[,] GetGrid()
        {
            return grid;
        }
    }

    
}