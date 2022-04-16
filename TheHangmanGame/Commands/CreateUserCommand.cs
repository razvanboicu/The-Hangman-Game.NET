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
    public class CreateUserCommand : CommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly UserStore _userStore;

        public CreateUserCommand(RegisterViewModel viewModel, UserStore userStore)
        {
            _registerViewModel = viewModel;
            _userStore = userStore;
        }

        public override void Execute(object parameter)
        {
            if(_registerViewModel.Username != null && _registerViewModel.Password != null)
            {
                User user = new User()
                {
                    username = _registerViewModel.Username,
                    password = _registerViewModel.Password
                };
                _userStore.CreateUser(user);
            }
        }
    }
}
