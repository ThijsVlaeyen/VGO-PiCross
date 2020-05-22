using Cells;
using CommonServiceLocator;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Utility;

namespace ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public GameViewModel(MainViewModel mainViewModel, Puzzle Puzzle)
        {
            this.Vm = mainViewModel;
            this.Facade = new PiCrossFacade();
            this.PlayablePuzzle = Facade.CreatePlayablePuzzle(Puzzle);
            this.Start(mainViewModel, PlayablePuzzle);
            this.MenuCommand = new Command(() => this.Vm.StartView());
            this.RestartCommand = new RestartCommand(this.Vm);
            this.LevelSelectionCommand = new Command(() => this.Vm.LevelSelect());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public PiCrossFacade Facade { get; }
        public IPlayablePuzzle PlayablePuzzle { get; private set; }
        public IGrid<PuzzleSquareViewModel> Grid { get; private set; }
        public MainViewModel Vm { get; private set; }
        public ICommand MenuCommand { get; }
        public Chronometer Chronometer { get; private set; }
        public ICommand RestartCommand { get; }
        public ICommand LevelSelectionCommand { get; }
        private DispatcherTimer timer;
        public ICommand OnStart { get; }

        public void Start(MainViewModel viewModel, IPlayablePuzzle puzzle)
        {
            this.Vm = viewModel;
            this.PlayablePuzzle = puzzle;
            this.Grid = this.PlayablePuzzle.Grid.Map(puzzlesquare => new PuzzleSquareViewModel(puzzlesquare)).Copy();
            this.Chronometer = new Chronometer();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(250);
            timer.Tick += (o, s) => 
            {
                if (IsSolved.Value)
                {
                    timer.Stop();
                    Chronometer.Pause();
                } else
                {
                    Chronometer.Tick();
                }
            };
            timer.Start();

            this.Chronometer.Start();
        }

        public Cell<bool> IsSolved
        {
            get
            {
                return PlayablePuzzle.IsSolved;
            }
        }
        public Cell<TimeSpan> time
        {
            get
            {
                return Chronometer.TotalTime;
            }
        }
    }
    public class RestartCommand : ICommand
    {
        private MainViewModel vm;

        public RestartCommand(MainViewModel mainViewModel)
        {
            vm = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.vm.StartGame(((IPlayablePuzzle)parameter).Grid.Size.Width);
        }
    }
}
