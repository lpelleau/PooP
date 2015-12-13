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
    /// Command for a change in map size
    /// </summary>
    public class ChangeMapSizeCommand : ICommand
    {
        private NewGameModel ngm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public ChangeMapSizeCommand(NewGameModel m)
        {
            ngm = m;
        }

        /// <summary>
        /// Changes the map size
        /// </summary>
        /// <param name="o">Choosen map size as a String</param>
        public void Execute(Object o)
        {
            ngm.MapSize = (string)o;
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
}
