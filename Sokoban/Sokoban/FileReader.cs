using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    internal class FileReader
    {
        string path;

        public FileReader()
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
        }

        public List<List<GameTile>> loadBoard()
        {
            List<List<GameTile>> board = new List<List<GameTile>>();

            bool exceptionOccured = true;
            Console.WriteLine("Type the file you want to play");

            // Keep asking for file until a valid one is entered
            while (exceptionOccured)
            {
                try
                {
                    readFile(board);
                    validateBoard();
                    exceptionOccured = false;
                }
                catch (Exception e)
                {
                    // Reset board and player
                    board = new List<List<GameTile>>();
                    Player.killPlayer();
                    Console.WriteLine("An error occurred while reading the file: " + e.Message +
                            "\nPlease try another file");
                }
            }

            Console.Clear();

            return board;

        }

        private void readFile(List<List<GameTile>> board)
        {
            string filename = Console.ReadLine();
            string file_path = Path.Combine(path, filename);

            // Check if file exists
            if (File.Exists(file_path))
            {
                
                // Read all lines from file
                string[] lines = File.ReadAllLines(file_path);

                if (lines.Length == 0) throw new Exception("File is empty");

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    List<GameTile> row = new List<GameTile>();

                    for (int j = 0; j < line.Length; j++)
                    {
                        // Create tile based on character
                        GameTile tile;

                        switch (line[j])
                        {
                            case ' ':
                                tile = new Empty(); break;
                            case '#':
                                tile = new Wall(); break;
                            case '$':
                                tile = new Chest(i, j); break;
                            case '.':
                                tile = new Target(); break;
                            case '@':
                                tile = Player.createPlayer(i, j); break;
                            case '+':
                                tile = Player.createPlayer(i, j, true); break;
                            case '*':
                                tile = new Chest(i, j, true); break;
                            default:
                                throw new Exception("Invalid character occurred in file");
                        }

                        row.Add(tile);
                    }
                    board.Add(row);
                }
            }
            else
            {
                throw new FileNotFoundException($"File {filename} not found");
            }
        }

        private void validateBoard()
        {
            if (Chest.numInstances > Target.numInstances) throw new Exception("There are more chests than targets in the file");
            if (Chest.numInstances < 1) throw new Exception("There are no chests in the file");
            if (Chest.numInstances == Chest.numInstancesOnTarget) throw new Exception("All chests are already on targets");
            if (Player.getPlayer() == null) throw new Exception("There is no player in the file");
        }
    }
}
