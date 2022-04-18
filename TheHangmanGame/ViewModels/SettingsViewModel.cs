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
    public class SettingsViewModel : ViewModelBase
    {
        private User _currentUserLoggedIn;
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
        private string _currentUsername;
        private int selectedIndex = 1;

        public User CurrentUserLoggedIn
        {
            get { return _currentUserLoggedIn; }
            set
            {
                _currentUserLoggedIn = value;
                OnPropertyChanged(nameof(User));
            }

        }
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public ImgPath ImagePath
        {
            get { return new BitmapImage(new Uri(@"/Imagez/NewFolder/" + selectedIndex + ".jpg", UriKind.Relative)); }
            set { ImagePath = value; }
        }
        public string CurrentUsername
        {
            get { return _currentUsername; }
            set { _currentUsername = value; }
        }

        public ICommand BackCommand { get; }
        public ICommand PreviousImageButton { get; }
        public ICommand NextImageButton { get; }
        public ICommand UpdateAvatar { get; }
        public ICommand DeleteAccount { get; }

        public SettingsViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
            _userStore = userStore;
            _navigationStore = navigationStore;
            _currentUserLoggedIn = user;
            _currentUsername = _currentUserLoggedIn.username;
            //OnPropertyChanged(nameof(CurrentUserLoggedIn));

            BackCommand = new NavigateCommand<AccountViewModel>(_navigationStore, () => new AccountViewModel(_navigationStore, _userStore, _currentUserLoggedIn));
            PreviousImageButton = new PrevImageCommand(this);
            NextImageButton = new NextImageCommand(this);
            UpdateAvatar = new UpdateAvatarCommand(this, _currentUserLoggedIn, _userStore);
            DeleteAccount = new DeleteAccountCommand(_navigationStore, _userStore, _currentUserLoggedIn);
        }
    }
}
