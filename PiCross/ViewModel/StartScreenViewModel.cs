using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class StartScreenViewModel
    {
        public StartScreenViewModel(MainViewModel mainWindowView)
        {
            this.vm = mainWindowView;
            this.LevelSelectCommand = new Command(() => this.vm.LevelSelect());
            this.CloseCommand = new Command(() => this.vm.CloseWindow());
            this.HighScoresCommand = new Command(() => this.vm.HighScoreWindow());
            this.OptionsCommand = new Command(() => this.vm.OptionsWindow());
        }

        private MainViewModel vm { get; }
        public ICommand LevelSelectCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand HighScoresCommand { get; }
        public ICommand OptionsCommand { get; }
    }
}
