using Memory.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    static internal class MemoryUtils
    {
        static string path = "images";

        public static ObservableCollection<CardVM> GenerateRandomLayout()
        {
            ObservableCollection<CardVM> cards = new ObservableCollection<CardVM>();


            // Get all image paths
            string[] fileNames = Directory.GetFiles(path);

            foreach (string fileName in fileNames)
            {
                // add cards to list
                cards.Add(new CardVM(fileName));
                cards.Add(new CardVM(fileName));
            }

            // shuffle cards
            for (int i = 0; i < 5; i++)
            {
                Shuffle(cards);
            }

            return cards;
        }

        public static void Shuffle<T>(ObservableCollection<T> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static bool CheckForMatch(List<CardVM> JustFlippedCards)
        {
            if (JustFlippedCards.Count == 2)
            {
                if (JustFlippedCards[0].Equals(JustFlippedCards[1]))
                {
                    return true;
                }
            }

            return false;
        }

        public static void NextTurn(MemoryVM memoryVM)
        {
            if (CheckForMatch(memoryVM.JustFlippedCards))
            {
                memoryVM.JustFlippedCards.Clear();
                memoryVM.CurrentPlayer.Score++;

                // Player gets another turn
                
                if (memoryVM.CurrentPlayer is Computer)
                {
                    memoryVM.Computer.Play();
                }
            }
            else
            {
                // Flip cards back over
                foreach (CardVM card in memoryVM.JustFlippedCards)
                {
                    card.IsFlipped = false;
                }

                memoryVM.JustFlippedCards.Clear();

                // Switch players
                if (memoryVM.CurrentPlayer == memoryVM.User1)
                {
                    memoryVM.CurrentPlayer = memoryVM.Player2;

                    if (memoryVM.Player2 is Computer)
                    {
                        memoryVM.Computer.Play();
                    }
                }
                else if (memoryVM.CurrentPlayer == memoryVM.Player2)
                {
                    memoryVM.CurrentPlayer = memoryVM.User1;
                }
            }
        }
    }
}
