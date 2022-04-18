using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TheHangmanGame.Commands;
using TheHangmanGame.Models;
using TheHangmanGame.Stores;
using ImgPath = System.Windows.Media.ImageSource;
namespace TheHangmanGame.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly User _currentUserWhoPlays;
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
        private string _currentUsername;
        private ImgPath _imagePath;

        private ObservableCollection<Models.Button> _firstKeyboardRow;
        private ObservableCollection<Models.Button> _secondKeyboardRow;
        private ObservableCollection<Models.Button> _thirdKeyboardRow;
        public ImgPath ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }
        public string CurrentUsername
        {
            get { return _currentUsername; }
            set { _currentUsername = value; }
        }
        public ICommand ExitGame { get; }
   
        public ObservableCollection<Models.Button> FirstKeyboardRow
        {
            get { return _firstKeyboardRow; }
            set { _firstKeyboardRow = value; }
        }
        public ObservableCollection<Models.Button> SecondKeyboardRow
        {
            get { return _secondKeyboardRow; }
            set { _secondKeyboardRow = value; }
        }
        public ObservableCollection<Models.Button> ThirdKeyboardRow
        {
            get { return _thirdKeyboardRow; }
            set { _thirdKeyboardRow = value; }
        }

        public ICommand KeyboardPressed { get; }
        public GameViewModel() { }
        public GameViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
            _firstKeyboardRow = KeyboardCollection.GetKeyboardButtons('A', 'J');
            _secondKeyboardRow = KeyboardCollection.GetKeyboardButtons('K', 'S');
            _thirdKeyboardRow = KeyboardCollection.GetKeyboardButtons('T', 'Z');
            KeyboardPressed = new KeyboardPressedCommand(this);
            ExitGame = new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore, userStore, _currentUserWhoPlays));
            _userStore = userStore;
            _currentUserWhoPlays = user;
            _navigationStore = navigationStore;
            CurrentUsername = _currentUserWhoPlays.username;
            ImagePath = _currentUserWhoPlays.avatarPath;
        }
    }
}
