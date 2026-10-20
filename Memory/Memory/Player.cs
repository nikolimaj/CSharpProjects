using Memory.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal abstract class Player: INotifyPropertyChanged
    {
        private string name;
        public string Name {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int score;
        public int Score { get{ return score; } set { score = value; OnPropertyChanged(nameof(Score)); } }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }
    }

    internal class User : Player
    {
        public User(string name) : base(name)
        {
        }
    }

    internal class Computer : Player
    {
        private Random random = new Random();
        private MemoryVM memoryVM;

        public Computer(MemoryVM memoryVM) : base("Computer")
        {
            this.memoryVM = memoryVM;
        }

        public void Play()
        {
            ObservableCollection<CardVM> cards = memoryVM.Cards;
            CardVM card1 = FlipRandomCard(cards);
            CardVM card2 = FlipRandomCard(cards);

            memoryVM.JustFlippedCards.Add(card1);
            memoryVM.JustFlippedCards.Add(card2);
        }

        private CardVM FlipRandomCard(ObservableCollection<CardVM> cards)
        {
            var unflippedCards = cards.Where(c => !c.IsFlipped).ToList();

            int index = random.Next(unflippedCards.Count);

            unflippedCards[index].IsFlipped = true;

            return unflippedCards[index];
        }
    }
}
