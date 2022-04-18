using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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
        private string _currentCategory;
        private readonly ECategory _eCategory;
        private ImgPath _imagePath;
        private string _wordToGuess;
        private int chancesLeft;
        private int indexOfHangman;
        private ImgPath _hangmanPath;

        private ObservableCollection<Models.Button> _firstKeyboardRow;
        private ObservableCollection<Models.Button> _secondKeyboardRow;
        private ObservableCollection<Models.Button> _thirdKeyboardRow;
        public ImgPath HangmanPath
        {
            get { return new BitmapImage(new Uri(@"/Imagez/Hangman/hangman" + indexOfHangman + ".jpg", UriKind.Relative)); }
            set { _hangmanPath = value; }
        }
        public int IndexOfHangman
        {
            get { return indexOfHangman; }
            set
            {
                indexOfHangman = value;
                OnPropertyChanged(nameof(HangmanPath));
            }
        }
        public int ChancesLeft
        {
            get { return chancesLeft; }
            set
            {
                chancesLeft = value;
                // OnPropertyChanged(nameof(ChancesLeft));
                // 
            }
        }
        public string WordToGuess
        {
            get { return _wordToGuess; }
            set { _wordToGuess = value; }
        }
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
        public string CurrentCategory
        {
            get { return _currentCategory; }
            set { _currentCategory = value; }
        }
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
            set
            {
                _thirdKeyboardRow = value;
                OnPropertyChanged(nameof(ThirdKeyboardRow));
            }
        }
        public ICommand KeyboardPressed { get; }

        public GameViewModel(NavigationStore navigationStore, UserStore userStore, User user, ECategory category)
        {
            _eCategory = category;
            InitializeTheHangmanIndexImage();
            InitializeTheGameCategory();
            _firstKeyboardRow = KeyboardGenerator.GetKeyboardButtons('A', 'J');
            _secondKeyboardRow = KeyboardGenerator.GetKeyboardButtons('K', 'S');
            _thirdKeyboardRow = KeyboardGenerator.GetKeyboardButtons('T', 'Z');
            KeyboardPressed = new KeyboardPressedCommand(this);
            ExitGame = new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore, userStore, _currentUserWhoPlays));
            _userStore = userStore;
            SetWordToGuess();
            _currentUserWhoPlays = user;
            _navigationStore = navigationStore;

            CurrentUsername = _currentUserWhoPlays.username;
            ImagePath = _currentUserWhoPlays.avatarPath;
        }
        public void InitializeTheHangmanIndexImage()
        {
            indexOfHangman = 4;
        }
        public void SetWordToGuess()
        {
            _wordToGuess = DataProvider.GetWordToGuess(_eCategory);
        }
        public void InitializeTheGameCategory()
        {
            switch (_eCategory)
            {
                case ECategory.eCars:
                    _currentCategory = "Cars category!";
                    break;
                case ECategory.eMovies:
                    _currentCategory = "Movies category!";
                    break;
                case ECategory.eCountries:
                    _currentCategory = "Countries category!";
                    break;
                default:
                    break;
            }

        }

    }
}
