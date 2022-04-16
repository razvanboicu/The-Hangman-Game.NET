using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheHangmanGame.Commands;
using TheHangmanGame.Stores;

namespace TheHangmanGame.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        //public string WelcomeMessage => "Aceasta este register window bro!!";
        private string _username;
        private string _password;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public ICommand NavigateLoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public RegisterViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            RegisterCommand = new CreateUserCommand(this, userStore);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore, userStore));
        }

    }
}
