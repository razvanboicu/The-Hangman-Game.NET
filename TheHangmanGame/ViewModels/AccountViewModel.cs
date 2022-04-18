using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TheHangmanGame.Commands;
using TheHangmanGame.Models;
using TheHangmanGame.Stores;
using ImgPath = System.Windows.Media.ImageSource;
namespace TheHangmanGame.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private User _currentUserLoggedIn;
        private string _currentUsername;
        private ImgPath _imagePath;
       
        public ImgPath ImagePath
        {
            get { return _currentUserLoggedIn.avatarPath; }
            set { _imagePath = value; }
        }

        public User CurrentUserLoggedIn
        {
            get { return _currentUserLoggedIn; }
        }
        public string CurrentUsername
        {
            get { return _currentUsername; }
            set { _currentUsername = value; }
        }
        public ICommand LogOutCommand { get; }
        public ICommand GoToSettingsCommand { get; }
        public ICommand NewGameCommand { get; }
        
        public AccountViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
            _currentUserLoggedIn = user;
            _currentUsername = _currentUserLoggedIn.username;
            GoToSettingsCommand = new NavigateCommand<SettingsViewModel>(navigationStore, () => new SettingsViewModel(navigationStore, userStore, _currentUserLoggedIn));
            LogOutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore, userStore));
            NewGameCommand = new NavigateCommand<CategoriesSelectorViewModel>(navigationStore, () => new CategoriesSelectorViewModel(_currentUserLoggedIn, navigationStore, userStore)); 
        }
    }
}
