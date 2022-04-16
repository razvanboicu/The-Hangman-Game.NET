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
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly UserStore _userStore;
        private readonly NavigationStore _navigationStore;


        public LoginCommand(LoginViewModel viewModel, UserStore userStore, NavigationStore navigationStore)
        {
            _loginViewModel = viewModel;
            _userStore = userStore;
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            //Console.WriteLine(_loginViewModel.Username + " " + _loginViewModel.Password);
            if (_loginViewModel.Username != null && _loginViewModel.Password != null)
                if (_userStore.SearchUser(new User(_loginViewModel.Username, _loginViewModel.Password)))
                {
                    Console.WriteLine("User found");
                    new NavigateCommand<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore, _userStore, new User(_loginViewModel.Username, _loginViewModel.Password))).Execute(this);
                }
                else
                    Console.WriteLine("User not found");


        }
    }
}
