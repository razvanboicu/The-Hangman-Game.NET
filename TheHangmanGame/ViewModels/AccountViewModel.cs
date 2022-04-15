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
    public class AccountViewModel : ViewModelBase
    {

        private readonly NavigationStore _navigationStore;

        public ICommand NavigateLoginCommand { get; }

        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateLoginCommand = new NavigateLoginCommand(navigationStore);
        }
    }
}
