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
        private CurrentGameModel currentGameModel;
        private PageInterface page;

        public MoveUnitCommand(CurrentGameModel currentGameModel, PageInterface page)
        {
            this.currentGameModel = currentGameModel;
            this.page = page;
        }


        public bool CanExecute(object parameter)
        {
            MoveCommand mv = new MoveCommand(SelectUnitCommand.SelectedUnit, new Position(Grid.GetColumn(currentGameModel.bo), Grid.GetRow(currentGameModel.bo)));
            return mv.canDo();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            MoveCommand mv = new MoveCommand(SelectUnitCommand.SelectedUnit, new Position(Grid.GetColumn(currentGameModel.bo), Grid.GetRow(currentGameModel.bo)));
            mv.execute();
            Grid.SetColumn(SelectUnitCommand.unitRect, SelectUnitCommand.SelectedUnit.Position.XPosition);
            Grid.SetRow(SelectUnitCommand.unitRect, SelectUnitCommand.SelectedUnit.Position.YPosition);
            currentGameModel.DrawUnits();
            page.OnReload();
        }
    }
}
