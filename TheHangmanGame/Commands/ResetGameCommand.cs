using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangmanGame.Models;
using TheHangmanGame.Stores;
using TheHangmanGame.ViewModels;

namespace TheHangmanGame.Commands
{
    public class ResetGameCommand : CommandBase
    {
        private GameViewModel _gameViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
        private User _currentUserLoggedIn;
        private readonly ECategory _eCategory;
        public ResetGameCommand(GameViewModel gameViewModel, NavigationStore navigationStore, UserStore userStore, User user, ECategory category)
        {
            _navigationStore = navigationStore;
            _userStore = userStore;
            _currentUserLoggedIn = user;
            _eCategory = category;
             _gameViewModel = gameViewModel;
        }
        public override void Execute(object parameter)
        {
            new NavigateCommand<GameViewModel>(_navigationStore, () => new GameViewModel(_navigationStore, _userStore, _currentUserLoggedIn, _eCategory)).Execute(this);
        }
    }
}
