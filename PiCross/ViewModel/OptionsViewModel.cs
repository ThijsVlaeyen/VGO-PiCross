using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class OptionsViewModel
    {
        public OptionsViewModel(MainViewModel mainViewModel)
        {
            this.vm = mainViewModel;
            this.MainMenuCommand = new Command(() => this.vm.StartView());
        }
        private MainViewModel vm { get; }
        public ICommand MainMenuCommand { get; }
    }
}
