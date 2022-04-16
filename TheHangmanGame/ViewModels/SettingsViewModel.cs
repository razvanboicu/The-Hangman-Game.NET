using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheHangmanGame.Commands;
using TheHangmanGame.Models;
using TheHangmanGame.Stores;

namespace TheHangmanGame.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private User _currentUserLoggedIn;
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
        private string _currentUsername;

        public string CurrentUsername
        {
            get { return _currentUsername; }
            set { _currentUsername = value; }
        }

        public ICommand BackCommand { get; }

        public SettingsViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
            _userStore = userStore;
            _navigationStore = navigationStore;
            _currentUserLoggedIn = user;
            _currentUsername = _currentUserLoggedIn.username;
            BackCommand = new NavigateCommand<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore, _userStore, _currentUserLoggedIn)) ;
            // GoToSettingsCommand =
            //LogOutCommand = new NavigateCommand<LoginViewModel>(_navigationStore, () => new LoginViewModel(_navigationStore, _userStore));
        }
    }
}
