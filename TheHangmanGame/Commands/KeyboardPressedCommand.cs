using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TheHangmanGame.ViewModels;

namespace TheHangmanGame.Commands
{
    public class KeyboardPressedCommand : CommandBase
    {
        private readonly GameViewModel _gameViewModel;
        public KeyboardPressedCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;   
        }
        public override void Execute(object parameter)
        {
            string text = (parameter.ToString());
            Console.WriteLine(text);
        }
    }
}
