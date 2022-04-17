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
        private KeyboardCollection _keyboardCollection = new KeyboardCollection();
        private string _currentUsername;
        private List<Button> _listView1;
        private List<Button> _listView2;
        private List<Button> _listView3;
        private ImgPath _imagePath;
        public List<Button> ListView1
        {
            get { return _listView1; }
            set { _listView1 = value; }
        }
        public List<Button> ListView2
        {
            get { return _listView2; }
            set { _listView2 = value; }
        }
        public List<Button> ListView3
        {
            get { return _listView3; }
            set { _listView3 = value; }
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

        public GameViewModel(NavigationStore navigationStore, UserStore userStore, User user)
        {
         
            _listView1 = _keyboardCollection.GetKeyboardFrom('A', 'Q');
            _listView2 = _keyboardCollection.GetKeyboardFrom('A', 'Q');
            _listView3 = _keyboardCollection.GetKeyboardFrom('A', 'Q');
            foreach (var button in _listView1)
            {
                //Console.WriteLine( + "\n");
            }
            ExitGame = new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore, userStore, _currentUserWhoPlays));
            _userStore = userStore;
            _currentUserWhoPlays = user;
            _navigationStore = navigationStore;
            CurrentUsername = _currentUserWhoPlays.username;
            ImagePath = _currentUserWhoPlays.avatarPath;
        }
    }
}
