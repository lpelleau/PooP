using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.MainMenu
{
    /// <summary>
    /// Command to display the credits
    /// </summary>
    public class CreditCommand : ICommand
    {
        private WindowInterface window;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Current window</param>
        public CreditCommand(WindowInterface m)
        {
            this.window = m;
        }

        /// <summary>
        /// Displays the credits
        /// </summary>
        /// <param name="o">Unused</param>
        public void Execute(Object o)
        {
            window.OpenCredits();
        }

        /// <summary>
        /// Tests if the command can be executed
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>Always true</returns>
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
