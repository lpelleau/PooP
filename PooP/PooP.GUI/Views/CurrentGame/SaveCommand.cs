using PooP.Core.Implementation.Games;
using PooP.GUI.Views.LoadGame;
using PooP.GUI.Views.NewGame;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PooP.GUI.Views.CurrentGame
{
    /// <summary>
    /// Command to start the page of a game
    /// </summary>
    public class SaveCommand : ICommand
    {
        private CurrentGameModel cgm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">Parent window</param>
        public SaveCommand(CurrentGameModel cgm)
        {
            this.cgm = cgm;
        }

        /// <summary>
        /// Starts the page
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            SaveChoser.INSATANCE.SaveGame(cgm.FileName);
        }

        /// <summary>
        /// Allaways possible
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>true</returns>
        public bool CanExecute(Object o)
        {
            return true;//!cgm.FileName.Equals(""); // TODO
        }

        /// <summary>
        /// Handler for a change in the conditions
        /// Called whenever one of the used variables changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                
            }
        }
    }
}
