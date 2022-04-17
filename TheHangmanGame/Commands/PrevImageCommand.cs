using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangmanGame.Stores;
using TheHangmanGame.ViewModels;

namespace TheHangmanGame.Commands
{
    public class PrevImageCommand : CommandBase
    {
        private SettingsViewModel _settingsViewModel;

        public PrevImageCommand(SettingsViewModel settingsViewModel)
        {
            _settingsViewModel = settingsViewModel;
        }

        public override void Execute(object parameter)
        {   
            if (_settingsViewModel.SelectedIndex > 1)
                _settingsViewModel.SelectedIndex--;
            else _settingsViewModel.SelectedIndex = 6;
        }
    }
}
