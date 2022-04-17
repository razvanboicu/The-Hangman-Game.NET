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
    public class UpdateAvatarCommand : CommandBase
    {
        private SettingsViewModel _settingsViewModel;
        private User _userForNewSettings;
        private UserStore _userStore;

        public UpdateAvatarCommand(SettingsViewModel settingsViewModel, User user, UserStore userStore)
        {
            _settingsViewModel = settingsViewModel;
            _userForNewSettings = user;
            _userStore = userStore;
        }
        
        public override void Execute(object parameter)
        {
            _userStore.UpdateAvatarProfile(_userForNewSettings, _settingsViewModel.ImagePath);
        }
    }
}
