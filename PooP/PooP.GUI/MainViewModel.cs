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
    /// <summary>
    /// ViewModel of the initialization window
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// Constructor
        /// Puts an empty string in all the values for game instanciation
        /// </summary>
        public MainViewModel()
        {
            Player1Name = "";
            Player2Name = "";
            Player1Race = "";
            Player2Race = "";
            MapSize = "";
        }

        // The launch command
        public ICommand Launch
        {
            get
            {
                return new LaunchCommand(this);
            }
        }

        // Command for a change in P1's race
        public ICommand ChangeRace1
        {
            get
            {
                return new ChangeRace1Command(this);
            }
        }

        // Command for a change in P2's race
        public ICommand ChangeRace2
        {
            get
            {
                return new ChangeRace2Command(this);
            }
        }

        // Command for a change in the map size
        public ICommand ChangeMapSize
        {
            get
            {
                return new ChangeMapSizeCommand(this);
            }
        }

        // Values for game creation

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

    /// <summary>
    /// Command for a change in P1's race
    /// </summary>
    public class ChangeRace1Command : ICommand
    {
        private MainViewModel mvm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public ChangeRace1Command(MainViewModel m)
        {
            mvm = m;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="o">The name of the choosen race</param>
        public void Execute(Object o)
        {
            mvm.Player1Race = (string) o;
        }

        /// <summary>
        /// Tests the possibillity of changing the race
        /// </summary>
        /// <param name="o">Name of the choosen race</param>
        /// <returns>true</returns>
        public bool CanExecute(Object o)
        {
            return true;
        }

        /// <summary>
        /// Handler for a change in the execution conditions
        /// Never called since the condition never changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }

    /// <summary>
    /// Command for a change in P2's race
    /// </summary>
    public class ChangeRace2Command : ICommand
    {
        private MainViewModel mvm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public ChangeRace2Command(MainViewModel m)
        {
            mvm = m;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="o">The name of the choosen race</param>
        public void Execute(Object o)
        {
            mvm.Player2Race = (string)o;
        }

        /// <summary>
        /// Tests the possibillity of changing the race
        /// </summary>
        /// <param name="o">Name of the choosen race</param>
        /// <returns>true</returns>
        public bool CanExecute(Object o)
        {
            return true;
        }

        /// <summary>
        /// Handler for a change in the execution conditions
        /// Never called since the condition never changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }

    /// <summary>
    /// Command for a change in map size
    /// </summary>
    public class ChangeMapSizeCommand : ICommand
    {
        private MainViewModel mvm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public ChangeMapSizeCommand(MainViewModel m)
        {
            mvm = m;
        }

        /// <summary>
        /// Changes the map size
        /// </summary>
        /// <param name="o">Choosen map size as a String</param>
        public void Execute(Object o)
        {
            mvm.MapSize = (string)o;
        }

        /// <summary>
        /// Tests if the map size can be changed
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>true since it can always be changed</returns>
        public bool CanExecute(Object o)
        {
            return true;
        }

        /// <summary>
        /// Handler called for a change in command conditions
        /// Never called since CanExecute is constant
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }

    /// <summary>
    /// Command to launch the game
    /// </summary>
    public class LaunchCommand : ICommand
    {
        private MainViewModel mvm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated view model</param>
        public LaunchCommand(MainViewModel m)
        {
            mvm = m;
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            // Gets the values for game initialization
            string[] playersNames = { mvm.Player1Name, mvm.Player2Name };
            string[] playersRaces = { mvm.Player1Race, mvm.Player2Race };

            // Creates the game
            GameBuilderFactory.get(mvm.MapSize).createGame(playersNames, playersRaces);

            // Closes the current window
            ((MainWindow)o).Close();

            // Launch the other window
            // TO DO : Replace by the correct code
            MessageBox.Show("Jeu " + mvm.MapSize + " généré avec : \n - J1 : " +
                mvm.Player1Name + " de race " + mvm.Player1Race + "\n - J2 : " +
                mvm.Player2Name + " de race " + mvm.Player2Race);
        }

        /// <summary>
        /// Tests if there are enough informations to launch the game
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>true if all the needed infos are given</returns>
        public bool CanExecute(Object o)
        {
            return !mvm.Player1Name.Equals("")
                && !mvm.Player2Name.Equals("")
                && !mvm.Player1Race.Equals("")
                && !mvm.Player2Race.Equals("")
                && !mvm.MapSize.Equals("");
        }

        /// <summary>
        /// Handler for a change in the conditions
        /// Called whenever one of the used variables changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
