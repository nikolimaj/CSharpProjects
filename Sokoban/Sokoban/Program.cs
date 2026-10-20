using System.IO;


namespace Sokoban
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard();

            while (true)
            {

                board.Print();

                bool endgame = false;

                while (!endgame)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            board.movePlayer(0, -1);
                            break;
                        case ConsoleKey.RightArrow:
                            board.movePlayer(0, 1);
                            break;
                        case ConsoleKey.UpArrow:
                            board.movePlayer(-1, 0);
                            break;
                        case ConsoleKey.DownArrow:
                            board.movePlayer(1, 0);
                            break;
                        case ConsoleKey.Escape:
                            endgame = true;
                            Console.Clear();
                            Console.WriteLine("DDo you want to play another game?");
                            break;
                    }

                    if (Chest.numInstances == Chest.numInstancesOnTarget)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations, you won! Number of moves: " + board.moves);
                        Console.WriteLine("Do you want to play again?");
                        endgame = true;
                    }
                }

                board.Reset();

            }
        }
    }
}