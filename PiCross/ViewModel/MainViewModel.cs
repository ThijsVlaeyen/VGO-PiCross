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
            Debug.WriteLine("Constructor Main viewmodel");
            this.ActiveWindow = new StartScreenViewModel(this);
            this.PiCrossFacade = new PiCrossFacade();
        }

        public PiCrossFacade PiCrossFacade { get; }
        private object activeWindow;
        public Action ClosingAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

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

        public void HighScoreWindow()
        {
            this.ActiveWindow = new HighScoreViewModel(this);
        }

        public void OptionsWindow()
        {
            this.ActiveWindow = new OptionsViewModel(this);
        }

        public void StartGame(int Size)
        {

            this.ActiveWindow = new GameViewModel(this, Puzzle.FromRowStrings(this.RandomPuzzle(Size)));
        }

        public String[] RandomPuzzle(int x)
        {
            Random rnd = new Random();
            String[] output = new String[x];

            for (int i = 0; i < x; i++)
            {
                String line = "";
                for (int j = 0; j < x; j++)
                {
                    if (rnd.Next(3) == 0)
                    {
                        line += ".";
                    }
                    else
                    {
                        line += "x";
                    }
                }
                output[i] = line;
            }
            return output;
        }
    }
}
