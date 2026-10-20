using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken
{
    internal class Opponent
    {

        public PlacementBoard board;
        public GuessingBoard guessingBoard;


        public Opponent(GuessingBoard guessingBoard)
        {
            this.guessingBoard = guessingBoard;
            board = new PlacementBoard(guessingBoard.columns, guessingBoard.rows);
            generateBoard();
        }


        private Random random = new Random();

        private void generateBoard()
        {
            while (!board.isValid())
            {
                addShip();
            }

        }

        private bool validGuess(int row, int col)
        {
            if (guessingBoard.GetState(row, col) == State.Unknown)
            {

                for (int i = -1; i <=1; i++)
                {
                    for (int j = -1; j <=1; j++)
                    {
                        int posX = i + row;
                        int posY = j + col;

                        if (posX < 0 || posX >= board.rows || posY < 0 || posY >= board.columns)
                        {
                            continue;
                        }

                        if (guessingBoard.GetState(posX, posY) == State.Sunk || guessingBoard.GetState(posX, posY) == State.Hit)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            return false;
        }

        private void addShip()
        {
            int length = board.MaxShipLength();

            int posX = random.Next(0, 10);
            int posY = random.Next(0, 10);

            bool horizontal = random.Next(0, 2) == 0;

            bool valid = true;

            for (int i = 0; i < length && valid; i++)
            {
                int x = horizontal ? posX : posX + i;
                int y = horizontal ? posY + i : posY;

                valid = board.isValidShipPos(x, y);
            }

            if (valid)
            {
                for (int i = 0; i < length; i++)
                {
                    int x = horizontal ? posX : posX + i;
                    int y = horizontal ? posY + i : posY;

                    board.toggleState(x, y);
                }
            }
        }


        public (int, int) TakeTurn()
        {
            int row, col;

            HashSet<Ship> ships = guessingBoard.getRevealedShips();

            IEnumerable<Ship> notSunk = guessingBoard.getRevealedShips().Where(s => !s.IsSunk);

            if (notSunk.Count() > 0)
            {
                Ship ship = notSunk.First();

                foreach (IGameTile tile in ship.Tiles.Where(t => t.State == State.Hit))
                {

                    // try surrounding tiles
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (ship.direction == Direction.Horizontal && y != 0)
                            {
                                continue;
                            }
                            if (ship.direction == Direction.Vertical && x != 0)
                            {
                                continue;
                            }

                            if (x == 0 || y == 0)
                            {
                                int posX = tile.PosX + x;
                                int posY = tile.PosY + y;

                                if (posX < 0 || posX >= guessingBoard.rows || posY < 0 || posY >= guessingBoard.columns)
                                {
                                    continue;
                                }

                                if (guessingBoard.GetState(posX, posY) == State.Unknown)
                                {
                                    return (posX, posY);
                                }
                            }
                        }
                    }
                }
            }

            do
            {
                row = random.Next(0, 10);
                col = random.Next(0, 10);
            }
            while (!validGuess(row, col));


            return (row, col);
        }
    }
}

