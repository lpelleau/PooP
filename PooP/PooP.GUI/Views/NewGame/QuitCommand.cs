using PooP.GUI.Views.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interface.Views.NewGame
{
    /// <summary>
    /// Command for quitting the game
    /// </summary>
    public class QuitCommand : ICommand
    {
        private NewGameModel ngm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public QuitCommand(NewGameModel m)
        {
            ngm = m;
        }

        /// <summary>
        /// Quits
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            //((NewGame)o).Close();
        }

        /// <summary>
        /// Tests if the game can be exited
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>true</returns>
        public bool CanExecute(Object o)
        {
            return true;
        }

        /// <summary>
        /// Never called since CanExecute is constant
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
