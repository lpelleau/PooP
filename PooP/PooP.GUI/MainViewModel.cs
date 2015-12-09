using PooP.Core.Implementation.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Interface
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Player1Name = "";
            Player2Name = "";
            Player1Race = "";
            Player2Race = "";
        }

        public ICommand Launch
        {
            get
            {
                return new LaunchCommand(this);
            }
        }

        public ICommand ChangeRace1
        {
            get
            {
                return new ChangeRace1Command(this);
            }
        }

        public ICommand ChangeRace2
        {
            get
            {
                return new ChangeRace2Command(this);
            }
        }

        public ICommand ChangeMapSize
        {
            get
            {
                return new ChangeMapSizeCommand(this);
            }
        }

        public string Player1Name
        {
            get;
            set;
        }

        public string Player2Name
        {
            get;
            set;
        }

        // TO DO : Add a listener for the races
        public string Player1Race
        {
            get;
            set;
        }

        public string Player2Race
        {
            get;
            set;
        }

        public string MapSize
        {
            get;
            set;
        }
    }

    public class ChangeRace1Command : ICommand
    {
        private MainViewModel mvm;

        public ChangeRace1Command(MainViewModel m)
        {
            mvm = m;
        }

        public void Execute(Object o)
        {
            mvm.Player1Race = (string) o;
        }

        public bool CanExecute(Object o)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }

    public class ChangeRace2Command : ICommand
    {
        private MainViewModel mvm;

        public ChangeRace2Command(MainViewModel m)
        {
            mvm = m;
        }

        public void Execute(Object o)
        {
            mvm.Player2Race = (string)o;
        }

        public bool CanExecute(Object o)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }

    public class ChangeMapSizeCommand : ICommand
    {
        private MainViewModel mvm;

        public ChangeMapSizeCommand(MainViewModel m)
        {
            mvm = m;
        }

        public void Execute(Object o)
        {
            mvm.MapSize = (string)o;
        }

        public bool CanExecute(Object o)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }

    public class LaunchCommand : ICommand
    {
        private MainViewModel mvm;
        public LaunchCommand(MainViewModel m)
        {
            mvm = m;
        }

        public void Execute(Object o)
        {
            string[] playersNames = { mvm.Player1Name, mvm.Player2Name };
            string[] playersRaces = { mvm.Player1Race, mvm.Player2Race };

            GameBuilderFactory.get(mvm.MapSize).createGame(playersNames, playersRaces);

            // Launch the other window
        }

        public bool CanExecute(Object o)
        {
            return !mvm.Player1Name.Equals("")
                && !mvm.Player2Name.Equals("")
                && !mvm.Player1Race.Equals("")
                && !mvm.Player2Race.Equals("")
                && !mvm.MapSize.Equals("");
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
