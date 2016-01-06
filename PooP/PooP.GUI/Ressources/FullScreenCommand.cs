using PooP.Core.Implementation.Games;
using PooP.GUI.Views;
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
using System.Windows.Media.Imaging;

namespace PooP.GUI.Ressources
{
    /// <summary>
    /// Command to quit the application
    /// </summary>
    public class FullScreenCommand : ICommand
    {
        private WindowInterface window;
        private Page page;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">Parent window</param>
        public FullScreenCommand(WindowInterface window, Page page)
        {
            this.page = page;
            this.window = window;
        }

        /// <summary>
        /// Starts the page
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            if (window.IsfullScreen())
            {
                ((Image)page.FindName("FullscreenStyle")).Source = new BitmapImage(new Uri("../../images/pages/expand.png", UriKind.Relative));
                window.SmallScreen();
            }
            else
            {
                ((Image)page.FindName("FullscreenStyle")).Source = new BitmapImage(new Uri("../../images/pages/contract.png", UriKind.Relative));
                window.FullScreen();
            }
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
