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
    public class AccountViewModel : ViewModelBase
    {
        //private readonly NavigationStore _navigationStore;
        private User _currentUserLoggedIn;
        private string _currentUsername;

        public User CurrentUserLoggedIn
        {
            get { return _currentUserLoggedIn; }
        }
        public string CurrentUsername
        {
            get { return _currentUsername; }
            set { _currentUsername = value; }
        }

        public ICommand LogOutCommand { get; }
        public ICommand GoToSettingsCommand { get; }
        public AccountViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
            _currentUserLoggedIn = user;
            _currentUsername = _currentUserLoggedIn.username;
            GoToSettingsCommand = new SettingsCommand(this, userStore, navigationStore, _currentUserLoggedIn);
            LogOutCommand = new NavigateCommand<LoginViewModel>(navigationStore, ()=> new LoginViewModel(navigationStore, userStore));
        }
    }
}
