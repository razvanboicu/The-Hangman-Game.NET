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
    public class DeleteAccountCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
        private User _userForDelete;

        public DeleteAccountCommand(NavigationStore navigationStore, UserStore userStore, User userForDelete) 
        {
            _navigationStore = navigationStore;
            _userStore = userStore;
            _userForDelete = userForDelete;
        }
        public override void Execute(object parameter)
        {
            _userStore.DeleteUser(_userForDelete);
            new NavigateCommand<LoginViewModel>(_navigationStore, () => new LoginViewModel(_navigationStore, _userStore)).Execute(this);
        }
    }
}
