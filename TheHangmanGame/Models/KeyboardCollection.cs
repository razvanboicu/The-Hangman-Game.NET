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
        public List<Button> GetKeyboardFrom(char from, char to)
        {
            List<Button> arrayOfButtons = new List<Button>();
            for (int i = 0; i <= ((to - '0') - (from - '0')); i++)
            {
                arrayOfButtons.Add(new Button()
                {
                    Height = 25,
                    Width = 25,
                    Content = (from - '0' + i - '0') + '0',
                    Background = new SolidColorBrush(Colors.White),
                    BorderBrush = new SolidColorBrush(Colors.White),
                    Foreground = new SolidColorBrush(Colors.Black)
                }) ;
            }
            Console.WriteLine(arrayOfButtons.Count());

            return arrayOfButtons;
        }
    }
}
