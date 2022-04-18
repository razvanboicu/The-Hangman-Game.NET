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
            //string searched = "A";
            string text = (parameter.ToString());
          
            for (int i=0;i< _gameViewModel.FirstKeyboardRow.Count; i++)
            {
                if(_gameViewModel.FirstKeyboardRow[i].Letter == text)
                {
                    Console.WriteLine(text + _gameViewModel.FirstKeyboardRow[i].Visible);
                    _gameViewModel.FirstKeyboardRow[i].Visible = false;
                    Console.WriteLine(text + _gameViewModel.FirstKeyboardRow[i].Visible);
                }
            }
           
        }
    }
}
