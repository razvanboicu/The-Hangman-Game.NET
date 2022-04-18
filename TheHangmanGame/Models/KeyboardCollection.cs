using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheHangmanGame.Models
{
    public class KeyboardCollection
    {
        static public ObservableCollection<Button> GetKeyboardButtons(char from, char to)
        {
            ObservableCollection<Button> arrayOfButtons = new ObservableCollection<Button>();
            for (int i = 0; i <= ((to - '0') - (from - '0')); i++)
            {
                char c = (char)((char)(((from - '0') + i - 1 ) - '0') + 'a');
                arrayOfButtons.Add(new Button(c.ToString(), "Visibile"));
            }
            //Console.WriteLine(arrayOfButtons.Count());

            return arrayOfButtons;
        }
    }
}
