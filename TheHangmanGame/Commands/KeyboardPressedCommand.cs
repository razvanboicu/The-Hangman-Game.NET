using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
            
            if (_gameViewModel.ChancesLeft > 0)
            {
                if (!CheckIfIWin(_gameViewModel.InProgressWordToGuess))
                {
                    bool found = false;
                    for (int i = 0; i < _gameViewModel.WordToGuess.Length; i++)
                    {
                        if (_gameViewModel.WordToGuess[i].ToString() == buttonPressed)
                        {
                            _gameViewModel.InProgressWordToGuess = PutCharatersInWord(_gameViewModel.InProgressWordToGuess, _gameViewModel.WordToGuess, buttonPressed);
                            if (CheckIfIWin(_gameViewModel.InProgressWordToGuess))
                                MessageBox.Show("Congrats! You won");
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
                        {
                            MessageBox.Show("YOU LOST!");
                        }
                    }
                }
                else
                    MessageBox.Show("Congrats! You won");
            }
            else
                MessageBox.Show("YOU LOST!");
        }
        private bool CheckIfIWin(string wordForModifies)
        {
            char[] array = wordForModifies.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '*')
                    return false;
            }
            return true;
        }
        private void ResetKeyboard(string letterPressed)
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
        private string PutCharatersInWord(string wordForModifies, string word, string buttonPressedLetter)
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
