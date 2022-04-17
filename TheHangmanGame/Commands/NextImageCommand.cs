using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHangmanGame.ViewModels;

namespace TheHangmanGame.Commands
{
    public class NextImageCommand : CommandBase
    {
        private SettingsViewModel _settingsViewModel;

        public NextImageCommand(SettingsViewModel settingsViewModel)
        {
            _settingsViewModel = settingsViewModel;
        }
        public override void Execute(object parameter)
        {
            if (_settingsViewModel.SelectedIndex < 6)
                _settingsViewModel.SelectedIndex++;
            else _settingsViewModel.SelectedIndex = 1;
        }
    }
}
