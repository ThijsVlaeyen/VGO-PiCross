using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.ActiveWindow = new StartScreenViewModel(this);
            this.PiCrossFacade = new PiCrossFacade();
            this.Theme = new Theme(this);
            SetDefault();
        }

        public PiCrossFacade PiCrossFacade { get; }
        private object activeWindow;
        public Action ClosingAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Theme Theme { get; }

        public object ActiveWindow
        {
            get
            {
                return activeWindow;
            }
            private set
            {
                activeWindow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveWindow)));
            }
        }

        public void LevelSelect()
        {
            this.ActiveWindow = new LevelSelectViewModel(this);
        }

        public void StartView()
        {
            this.ActiveWindow = new StartScreenViewModel(this);
        }

        public void CloseWindow()
        {
            this.ClosingAction?.Invoke();
        }

        public void OptionsWindow()
        {
            this.ActiveWindow = new OptionsViewModel(this);
        }

        public void StartGame(int Size)
        {

            this.ActiveWindow = new GameViewModel(this, Puzzle.Random(Size));
        }

        public void SetVaporwave()
        {
            this.Theme.Vaporwave();
        }

        public void SetDefault()
        {
            this.Theme.Default();
        }

        public void SetJJBA()
        {
            this.Theme.JJBA();
        }
    }
}
