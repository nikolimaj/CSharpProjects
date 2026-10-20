using Memory.ViewModel;
using System.Runtime.Intrinsics.X86;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemoryVM memoryVM = new MemoryVM();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = memoryVM;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (memoryVM.JustFlippedCards.Count < 2 &&  memoryVM.CurrentPlayer is User)
            {
                var image = sender as Image;
                var card = image.DataContext as CardVM;

                if (!card.IsFlipped)
                {
                    card.IsFlipped = !card.IsFlipped;

                    memoryVM.JustFlippedCards.Add(card);

                    if (memoryVM.Cards.Count(c => !c.IsFlipped) == 0)
                    {
                        memoryVM.NextTurn();
                        memoryVM.GameOver();
                    }
                }


            }
        }


        private Random random = new Random();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (memoryVM.GameNotStarted)
            {
                memoryVM.GameNotStarted = false;

                // randomly choose who goes first
                if (random.Next(2) == 0)
                {
                    memoryVM.CurrentPlayer = memoryVM.User1;
                }
                else
                {
                    memoryVM.CurrentPlayer = memoryVM.Player2;
                    if (memoryVM.Player2 is Computer)
                    {
                        memoryVM.Computer.Play();
                    }
                }
            }
            else
            {
                memoryVM.NextTurn();
            }

        }
    }
}