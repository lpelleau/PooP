using PooP.Core.Implementation.Games;
using PooP.GUI.Views.NewGame;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.NewGame
{
    /// <summary>
    /// Command to launch the game
    /// </summary>
    public class LaunchCommand : ICommand
    {
        private NewGameModel ngm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated view model</param>
        public LaunchCommand(NewGameModel m)
        {
            ngm = m;
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            // Gets the values for game initialization
            string[] playersNames = { ngm.Player1Name, ngm.Player2Name };
            string[] playersRaces = { ngm.Player1Race, ngm.Player2Race };

            // Creates the game
            GameBuilderFactory.get(ngm.MapSize).createGame(playersNames, playersRaces);

            // Closes the current window
            //((MainWindow)o).Close();

            // Launch the other window
            ngm.window.OpenCurrentGame();
        }

        /// <summary>
        /// Tests if there are enough informations to launch the game
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>true if all the needed infos are given</returns>
        public bool CanExecute(Object o)
        {
            return !ngm.Player1Name.Equals("")
                && !ngm.Player2Name.Equals("")
                && !ngm.Player1Race.Equals("")
                && !ngm.Player2Race.Equals("")
                && !ngm.MapSize.Equals("");
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
