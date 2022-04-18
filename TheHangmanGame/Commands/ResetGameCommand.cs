using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangmanGame.ViewModels;

namespace TheHangmanGame.Commands
{
    public class ResetGameCommand : CommandBase
    {
        private GameViewModel _gameViewModel;
        public ResetGameCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }
        public override void Execute(object parameter)
        {
            _gameViewModel.ResetGame();
        }
    }
}
