using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHangmanGame.Models
{
    public class Button : INotifyPropertyChanged
    {
        private string _letter;
        public string Letter { get { return _letter; } set { _letter = value; OnPropertyChanged(nameof(Letter)); } }
        private bool _visible;
        public bool Visible { get { return _visible; } set { _visible = value; OnPropertyChanged(nameof(Visible)); } }

        public Button(string letter, bool available)
        {
            Letter = letter;
            Visible = available;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
