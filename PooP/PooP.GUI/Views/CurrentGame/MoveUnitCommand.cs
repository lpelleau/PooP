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

        public MoveUnitCommand(CurrentGameModel currentGameModel)
        {
            this.currentGameModel = currentGameModel;
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
            ListBox l = (ListBox)currentGameModel.page.FindName("UnitsP" + SelectUnitCommand.unitRef.Substring(SelectUnitCommand.unitRef.IndexOf("P")+1,SelectUnitCommand.unitRef.IndexOf("U") - (SelectUnitCommand.unitRef.IndexOf("P")+1)));
            List<RadioButton> lrb = (List<RadioButton>) l.ItemsSource;
            RadioButton r = lrb.First(rb => rb.Name.Equals("Bt" + SelectUnitCommand.unitRef));
            r.Content = r.Content.ToString().Substring(0, r.Content.ToString().IndexOf("(") + 1) + SelectUnitCommand.SelectedUnit.Position + r.Content.ToString().Substring(r.Content.ToString().IndexOf(")"));
        }
    }
}
