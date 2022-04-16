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
    class LoginViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Esti in fereastra de Login";
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateRegisterCommand { get; }
        public LoginViewModel(NavigationStore navigationStore)
        {
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore));
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
        }
    }
}
