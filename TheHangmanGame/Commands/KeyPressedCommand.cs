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
    public class KeyPressedCommand : CommandBase
    {
  
        private GameViewModel _gameViewModel;
       private ObservableCollection<Button> _keyboardRow;


        public KeyPressedCommand(GameViewModel gameViewModel, ObservableCollection<Button> keyboardRow)
        {
            _keyboardRow = keyboardRow;
            _gameViewModel = gameViewModel;
        }
        public override void Execute(object parameter)
        {
            var label = parameter as string;
            Console.Write(label);
        }
    }
}
