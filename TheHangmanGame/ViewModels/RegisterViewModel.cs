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
        public string WelcomeMessage => "Aceasta este register window bro!!";
        public ICommand NavigateLoginCommand { get; }
        public RegisterViewModel(NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }

    }
}
