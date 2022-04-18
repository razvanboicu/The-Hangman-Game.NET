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
        private GameViewModel _gameViewModel;
        public KeyboardPressedCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }
        public override void Execute(object parameter)
        {
            string buttonPressed = (parameter.ToString());
            //Console.WriteLine(buttonPressed);
            if (_gameViewModel.ChancesLeft > 0)
            {
                Console.WriteLine("Intrat in chances");
                bool found = false;
                for (int i = 0; i < _gameViewModel.WordToGuess.Length; i++)
                {
                    if (_gameViewModel.WordToGuess[i].ToString() == buttonPressed)
                    {
                        //Console.WriteLine("Egalul bun");
                        _gameViewModel.InProgressWordToGuess = PutCharatersInWord(_gameViewModel.InProgressWordToGuess, _gameViewModel.WordToGuess, buttonPressed);
                        //Console.WriteLine(_gameViewModel.InProgressWordToGuess);
                        ResetKeyboard(buttonPressed);
                        found = true;
                    }
                }
                ResetKeyboard(buttonPressed);
                if (!found)
                {
                    _gameViewModel.IndexOfHangman++;
                    _gameViewModel.ChancesLeft--;
                    if (_gameViewModel.ChancesLeft == 0)
                        Console.WriteLine("GAME OVER");
                }
            }
            else
                Console.WriteLine("GAME OVER");

        }
        public void ResetKeyboard(string letterPressed)
        {
            for (int i = 0; i < _gameViewModel.FirstKeyboardRow.Count; i++)
            {
                if (letterPressed == _gameViewModel.FirstKeyboardRow[i].Letter)
                {
                    _gameViewModel.FirstKeyboardRow[i].Visible = false;
                    return;
                }
            }
            for (int i = 0; i < _gameViewModel.SecondKeyboardRow.Count; i++)
            {
                if (letterPressed == _gameViewModel.SecondKeyboardRow[i].Letter)
                {
                    _gameViewModel.SecondKeyboardRow[i].Visible = false;
                    return;
                }
            }
            for (int i = 0; i < _gameViewModel.ThirdKeyboardRow.Count; i++)
            {
                if (letterPressed == _gameViewModel.ThirdKeyboardRow[i].Letter)
                {
                    _gameViewModel.ThirdKeyboardRow[i].Visible = false;
                    return;
                }
            }
        }
        public string PutCharatersInWord(string wordForModifies, string word, string buttonPressedLetter)
        {
            int index = 0;
            foreach (var it in word)
            {
                if (it == char.Parse(buttonPressedLetter))
                {
                    char[] array = wordForModifies.ToCharArray();
                    array[index] = char.Parse(buttonPressedLetter);
                    wordForModifies = new string(array);
                }
                index++;
            }
            return wordForModifies;
        }

    }
}
