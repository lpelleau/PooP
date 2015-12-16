using PooP.GUI.Views.NewGame;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.LoadGame
{
    /// <summary>
    /// Command for quitting the game
    /// </summary>
    public class BackCommand : ICommand
    {
        private WindowInterface window;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public BackCommand(WindowInterface window)
        {
            this.window = window;
        }

        /// <summary>
        /// Quits
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            window.CloseCurrent();
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
