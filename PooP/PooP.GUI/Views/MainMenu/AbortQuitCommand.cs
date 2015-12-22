using PooP.Core.Implementation.Games;
using PooP.GUI.Audio;
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

namespace PooP.GUI.Views.MainMenu
{
    /// <summary>
    /// Command to quit the application
    /// </summary>
    public class AbortQuitCommand : ICommand
    {
        private Page page;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">Parent window</param>
        public AbortQuitCommand(Page page)
        {
            this.page = page;
        }

        /// <summary>
        /// Starts the page
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            ((Canvas) page.FindName("confirmQuit")).Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Allaways possible
        /// </summary>
        /// <param name="o">Unused</param>
        /// <returns>true</returns>
        public bool CanExecute(Object o)
        {
            return true;
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
