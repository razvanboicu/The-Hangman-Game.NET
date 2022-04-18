using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheHangmanGame.Commands;
using TheHangmanGame.Models;
using TheHangmanGame.Stores;

public enum ECategory
{
    eCars,
    eMovies,
    eCountries
}

namespace TheHangmanGame.ViewModels
{
   
    public class CategoriesSelectorViewModel : ViewModelBase
    {
        private User _currentUserLoggedIn;
        private readonly NavigationStore _navigationStore;
        private readonly UserStore _userStore;
       

        public ICommand StartCarCategoryGame { get; }
        public ICommand StartMoviesCategoryGame { get; }
        public ICommand StartCountriesCategoryGame { get; }

        public CategoriesSelectorViewModel(User user, NavigationStore navigationStore, UserStore userStore )
        {
            _currentUserLoggedIn = user;
            _navigationStore = navigationStore;
            _userStore = userStore;
            StartCarCategoryGame = new NavigateCommand<GameViewModel>(navigationStore, () => new GameViewModel(navigationStore, userStore, _currentUserLoggedIn, ECategory.eCars));
            StartMoviesCategoryGame = new NavigateCommand<GameViewModel>(navigationStore, () => new GameViewModel(navigationStore, userStore, _currentUserLoggedIn, ECategory.eMovies));
            StartCountriesCategoryGame = new NavigateCommand<GameViewModel>(navigationStore, () => new GameViewModel(navigationStore, userStore, _currentUserLoggedIn, ECategory.eCountries));
        }
    }
}
