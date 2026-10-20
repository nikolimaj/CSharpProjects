using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memory.ViewModel
{
    internal class MemoryVM : INotifyPropertyChanged
    {
        public ObservableCollection<CardVM> Cards { get; set;}
        public int Rows { get; set; }
        public int Columns { get; set; }


        public Player User1 { get; set; }
        public User User2 { get; set; }

        public Computer Computer { get; set; }

        public Player Player2 { get { return Player2Computer ? Computer : User2; } }

        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; OnPropertyChanged(nameof(CurrentPlayer)); }
        }


        private bool gameNotStarted;
        public bool GameNotStarted { get { return gameNotStarted; } set { gameNotStarted = value; OnPropertyChanged(nameof(gameNotStarted)); } }


        private bool player2Computer;
        public bool Player2Computer { get { return player2Computer; } set { player2Computer = value; OnPropertyChanged(nameof(Player2)); } }

        public List<CardVM> JustFlippedCards { get; set; } = new List<CardVM>();

        public MemoryVM()
        {
            Cards = MemoryUtils.GenerateRandomLayout();

            int itemCount = Cards.Count;

            // Calculate the number of rows based on the total number of items and columns
            Columns = (int)Math.Ceiling(Math.Sqrt(itemCount));
            Rows = (int)Math.Ceiling((double)itemCount / Columns);

            User1 = new User("Player 1");
            User2 = new User("Player 2");
            Computer = new Computer(this);

            GameNotStarted = true;

        }

        public void NextTurn()
        {
            MemoryUtils.NextTurn(this);
        }

        public void GameOver()
        {
            string message = "";

            if (User1.Score > Player2.Score)
            {
                message = User1.Name + " wins!";
            }
            else if (User1.Score < Player2.Score)
            {
                message = Player2.Name + " wins!";
            }
            else
            {
                message = ("It's a tie!");
            }

            if (MessageBox.Show("Want to play again?", message, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Cards = MemoryUtils.GenerateRandomLayout();
                OnPropertyChanged(nameof(Cards));

                User1.Score = 0;
                User2.Score = 0;

                GameNotStarted = true;
                CurrentPlayer = null;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


