using PooP.GUI.Views.NewGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PooP.GUI.Views.NewGame
{
    /// <summary>
    /// Command for a change in P2's race
    /// </summary>
    public class ChangeRace2Command : ICommand
    {
        private NewGameModel ngm;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Associated ViewModel</param>
        public ChangeRace2Command(NewGameModel m)
        {
            ngm = m;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="o">The name of the choosen race</param>
        public void Execute(Object o)
        {
            ngm.Player2Race = ((RaceParameter)o).Name;
            ((System.Windows.Controls.Image)((RaceParameter)o).Image).Source = new BitmapImage(new Uri(ngm.Player2RaceImage, UriKind.Relative));
            ((System.Windows.Controls.TextBox)((RaceParameter)o).TextBox).FontFamily = new FontFamily(ngm.Player2RaceFont);
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
}
