using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.Core.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace PooP.GUI.Views.CurrentGame
{
    class AttackUnitCommand : ICommand
    {
        private CurrentGameModel cgm;
        private CurrentGameInterface page;

        public AttackUnitCommand(CurrentGameModel currentGameModel, CurrentGameInterface page)
        {
            this.cgm = currentGameModel;
            this.page = page;
        }

        public bool CanExecute(object parameter)
        {
            AttackCommand atk = new AttackCommand(SelectUnitCommand.SelectedUnit, new Position(Grid.GetColumn(cgm.bo), Grid.GetRow(cgm.bo)));
            return atk.canDo();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            AttackCommand atk = new AttackCommand(SelectUnitCommand.SelectedUnit, new Position(Grid.GetColumn(cgm.bo), Grid.GetRow(cgm.bo)));
            atk.execute();
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
