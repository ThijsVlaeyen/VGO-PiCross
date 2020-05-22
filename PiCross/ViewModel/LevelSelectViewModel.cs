using PiCross;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class LevelSelectViewModel
    {
        public LevelSelectViewModel(MainViewModel mainViewModel)
        {
            this.vm = mainViewModel;
            this.LevelSelectCommand = new LevelSelectCommand(mainViewModel);
            this.MainMenuCommand = new Command(() => this.vm.StartView());
        }

        private MainViewModel vm { get; }
        public ICommand LevelSelectCommand { get; }
        public ICommand MainMenuCommand { get; }
    }

    public class LevelSelectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainViewModel vm { get; }
        public Puzzle Puzzle;
        public LevelSelectCommand(MainViewModel mainViewModel)
        {
            this.vm = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.vm.StartGame(Int32.Parse(parameter as string));
        }
    }
}
