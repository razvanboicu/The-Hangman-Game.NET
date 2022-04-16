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
    public class LoginViewModel : ViewModelBase
    {
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

        public ICommand LogCommand {  get; }
        public ICommand NavigateRegisterCommand { get; }
       
        public LoginViewModel(NavigationStore navigationStore, UserStore userStore)
        {
            //LogButtonCommand = new LogInCommand(new User(_username, _password));
           // new NavigateCommand<AccountViewModel>(navigationStore, () => ......);
            LogCommand = new LoginCommand(this, userStore, navigationStore);
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore, userStore));
        }
    }
}
