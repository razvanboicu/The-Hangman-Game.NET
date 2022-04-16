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
    public class SettingsCommand : CommandBase
    {
        private readonly User _user;
        private readonly AccountViewModel _accountViewModel;
        private readonly UserStore _userStore;
        private readonly NavigationStore _navigationStore;

        public SettingsCommand(AccountViewModel viewModel, UserStore userStore, NavigationStore navigationStore, User currentUser)
        {
            _user = currentUser;
            _accountViewModel = viewModel;
            _userStore = userStore;
            _navigationStore = navigationStore;
        }
        
        public override void Execute(object parameter)
        {
            new NavigateCommand<SettingsViewModel>(_navigationStore, () => new SettingsViewModel(_navigationStore, _userStore, _accountViewModel.CurrentUserLoggedIn)).Execute(this);
        }
    }
}
