using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.Core.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PooP.GUI.Views.CurrentGame
{
    class MoveUnitCommand : ICommand
    {
        private CurrentGameModel cgm;
        private CurrentGameInterface page;

        public MoveUnitCommand(CurrentGameModel cgm, CurrentGameInterface page)
        {
            this.cgm = cgm;
            this.page = page;
        }


        public bool CanExecute(object parameter)
        {
            MoveCommand mv = new MoveCommand(SelectUnitCommand.SelectedUnit, new Position(Grid.GetColumn(cgm.bo), Grid.GetRow(cgm.bo)));
            return mv.canDo();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            MoveCommand mv = new MoveCommand(SelectUnitCommand.SelectedUnit, new Position(Grid.GetColumn(cgm.bo), Grid.GetRow(cgm.bo)));
            mv.execute();
            UndoableImpl.UndoneCommands.Clear();
            Grid.SetColumn(SelectUnitCommand.unitRect, SelectUnitCommand.SelectedUnit.Position.XPosition);
            Grid.SetRow(SelectUnitCommand.unitRect, SelectUnitCommand.SelectedUnit.Position.YPosition);
            cgm.DrawUnits();
            page.OnReload();
            cgm.PlaceHelp();
            ((Label)page.FindName("NameP0")).Content = 
                    GameBuilder.CURRENTGAME.Players[0].Name
                    + " (VP: " + GameBuilder.CURRENTGAME.Players[0].Race.getVictoryPoints() + ")";
            ((Label)page.FindName("NameP1")).Content =
                    GameBuilder.CURRENTGAME.Players[1].Name
                    + " (VP: " + GameBuilder.CURRENTGAME.Players[1].Race.getVictoryPoints() + ")";
        }
    }
}
