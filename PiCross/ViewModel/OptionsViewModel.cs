using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ViewModel
{
    public class OptionsViewModel
    {
        public OptionsViewModel(MainViewModel mainViewModel)
        {
            this.vm = mainViewModel;
            this.MainMenuCommand = new Command(() => this.vm.StartView());
            this.VaporwaveCommand = new Command(() => this.vm.SetVaporwave());
            this.DefaultCommand = new Command(() => this.vm.SetDefault());
            this.JJBACommand = new Command(() => this.vm.SetJJBA());
        }
        private MainViewModel vm { get; }
        public ICommand MainMenuCommand { get; }
        public ICommand VaporwaveCommand { get; }
        public ICommand DefaultCommand { get; }
        public ICommand JJBACommand { get; }
    }
}
