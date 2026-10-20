using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken
{
    internal class GuessingBoard : IGameBoard<IGameTile>
    {
        public int Guesses { get; set; } = 0;
        public GuessingBoard(PlacementBoard board, TableLayoutPanel gui)
        {
            grid = new IGameTile[board.GetGrid().GetLength(0), board.GetGrid().GetLength(1)];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col] = gui.GetControlFromPosition(row, col) as IGameTile;
                }
            }

            // copy ships
            foreach (Ship ship in board.ships)
            {
                Ship newShip = new Ship();
                foreach (IGameTile tile in ship.Tiles)
                {
                    grid[tile.PosX, tile.PosY].Ship = newShip;
                    newShip.Tiles.Add(grid[tile.PosX, tile.PosY]);
                }
                ships.Add(newShip);
            }
            
        }


        public bool Reveal(int row, int col)
        {
            Guesses++;

            if (grid[row, col].State == State.Unknown)
            {
                grid[row, col].Reveal();

                return grid[row, col].isShip;
            }
            return false;
        }

        public State GetState(int row, int col)
        {
            return grid[row, col].State;
        }

        public HashSet<Ship> getRevealedShips()
        {
            HashSet<Ship>  revealedShips = new HashSet<Ship>();

            foreach (Ship ship in ships)
            {
                foreach (IGameTile tile in ship.Tiles)
                {
                    if (tile.State == State.Hit || tile.State == State.Sunk)
                    {
                        revealedShips.Add(ship);
                        break;
                    }
                }
            }

            return revealedShips;
        }

        

        public bool Won()
        {
            foreach (Ship ship in ships)
            {
                if (!ship.IsSunk)
                {
                    return false;
                }
            }
            return true;
        }

    }
}

