using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PooP.GUI.Views.CurrentGame
{
    class SelectUnitCommand : ICommand
    {
        private CurrentGameModel cgm;
        public static Unit SelectedUnit;
        public static string unitRef;
        public static Rectangle unitRect;

        public SelectUnitCommand(CurrentGameModel cgm)
        {
            this.cgm = cgm;
            SelectedUnit = null;
        }

        public bool CanExecute(object parameter)
        {
            string uRef = ((Rectangle)parameter).Name.ToString();
            return Int16.Parse(uRef.Substring(uRef.IndexOf("P") + 1, uRef.IndexOf("U") - (uRef.IndexOf("P") + 1))) == GameBuilder.CURRENTGAME.IndexOfCurrentPlayer;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            unitRect = (Rectangle)parameter;
            unitRef = unitRect.Name.ToString();
            SelectedUnit = GameBuilder.CURRENTGAME.Players[Int16.Parse(unitRef.Substring(unitRef.IndexOf("P") + 1, unitRef.IndexOf("U") - (unitRef.IndexOf("P") + 1)))].Race.Units[Int16.Parse(unitRef.Substring(unitRef.IndexOf("U") + 1))];
        }
    }
}
