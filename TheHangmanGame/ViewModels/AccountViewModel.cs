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
        public ICommand NavigateLoginCommand { get; }

        public AccountViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
            _currentUserLoggedIn = user;
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, ()=> new LoginViewModel(navigationStore, userStore));
        }
    }
}
