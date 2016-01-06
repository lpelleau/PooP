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

namespace PooP.GUI.Audio
{
    /// <summary>
    /// Command to quit the application
    /// </summary>
    public class SoundCommand : ICommand
    {
        public static SoundCommand INSTANCE = new SoundCommand();
        private PageInterface page;

        public void SetPage(PageInterface page)
        {
            this.page = page;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window">Parent window</param>
        private SoundCommand()
        {
        }

        /// <summary>
        /// Starts the page
        /// </summary>
        /// <param name="o">Current window</param>
        public void Execute(Object o)
        {
            Sound.INSTANCE.ToogleMusic();
            page.OnReload();
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
