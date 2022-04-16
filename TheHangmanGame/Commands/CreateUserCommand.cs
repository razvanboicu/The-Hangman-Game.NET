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
    internal class CreateUserCommand : CommandBase
    {
        private readonly RegisterViewModel _viewModel;
        private readonly UserStore _userStore;

        public CreateUserCommand(RegisterViewModel viewModel, UserStore userStore)
        {
            _viewModel = viewModel;
            _userStore = userStore;
        }

        public override void Execute(object parameter)
        {
            if(_viewModel.Username != null && _viewModel.Password != null)
            {
                User user = new User()
                {
                    username = _viewModel.Username,
                    password = _viewModel.Password
                };
                _userStore.CreateUser(user);
            }

        }
    }
}
