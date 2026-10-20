using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.Json.Serialization;

namespace Sokoban
{
    internal class GameBoard
    {
        private List<List<GameTile>> board;
        private Player player;
        public int moves { get; private set; } = 0;

        public GameBoard()
        {
            initialize();
        }

        public void initialize()
        {
            // read board from file
            FileReader fileReader = new FileReader();
            board = fileReader.loadBoard();
            player = Player.getPlayer();
        }

        public void Print()
        {
            foreach (var row in board)
            {
                foreach (GameTile tile in row)
                {
                    Console.Write(tile.Symbol);
                }

                Console.WriteLine();

            }
        }

        public void Reset()
        {
            // reset board and initialize new game
            Player.killPlayer();
            Chest.numInstances = 0;
            Chest.numInstancesOnTarget = 0;
            moves = 0;

            initialize();
        }

        public void movePlayer(int x, int y)
        {
            // calculate new position
            int posX = player.x + x;
            int posY = player.y + y;

            if (!isValid(posX, posY)) return;

            GameTile movingTo = board[posX][posY];
            if (movingTo is Wall) return;

            if (movingTo is Chest)
            {
                // move chest
                Chest chest = movingTo as Chest;
                if(!isValid(posX + x, posY + y)) return;
                moveChest(chest, posX + x, posY + y);
                moveToPosition(player, posX, posY);
            }
            else
            {
                displayBeneath(player.standingOn, player.x, player.y);

                player.standingOn = board[posX][posY];

                moveToPosition(player, posX, posY);
            }

            // update number of moves
            moves++;
        }

        private void moveChest(Chest chest, int posX, int posY)
        {

            GameTile chestMovingTo = board[posX][posY];

            if (chestMovingTo is Wall || chestMovingTo is Chest) return;

            // update number of chests on targets
            if (chest.standingOn is Empty)
                if (chestMovingTo is Target) Chest.numInstancesOnTarget++;
            if (chest.standingOn is Target)
                if (chestMovingTo is Empty) Chest.numInstancesOnTarget--;

            displayBeneath(player.standingOn, player.x, player.y);

            // update standingOn
            player.standingOn = chest.standingOn;
            chest.standingOn = chestMovingTo;

            moveToPosition(chest, posX, posY);
        }


        private void moveToPosition(MovingGameTile gameTile, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(gameTile.Symbol);

            gameTile.x = x;
            gameTile.y = y;

            board[gameTile.x][gameTile.y] = gameTile;
        }

        private void displayBeneath(GameTile gameTile, int x, int y)
        {
            board[x][y] = gameTile;
            Console.SetCursorPosition(y, x);
            Console.Write(gameTile.Symbol);
        }

        private bool isValid(int x, int y)
        {
            return x >= 0 && x < board.Count && y >= 0 && y < board[x].Count;
        }
    }
}


