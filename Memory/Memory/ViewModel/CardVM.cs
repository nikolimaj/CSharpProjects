using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.ViewModel
{
    internal class CardVM : INotifyPropertyChanged
    {
        private static string BackImagePath = "back.jpg";
        private string FrontImagePath { get; set; }

        public string ImagePath
        {
            get
            {
                if (IsFlipped)
                {
                    return FrontImagePath;
                }
                else
                {
                    return BackImagePath;
                }
            }
        }
        private bool isFlipped;
        public bool IsFlipped
        {
            get { return isFlipped; }
            set { isFlipped = value; OnPropertyChanged(nameof(isFlipped)); OnPropertyChanged(nameof(ImagePath)); }

        }
        public CardVM(string path)
        {
            FrontImagePath = path;
            IsFlipped = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(CardVM other)
        {
            return FrontImagePath == other.FrontImagePath;
        }
    }
}
