﻿using PooP.Core.Implementation.Commands;
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

        public AttackUnitCommand(CurrentGameModel currentGameModel)
        {
            this.cgm = currentGameModel;
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
            Grid.SetColumn(SelectUnitCommand.unitRect, SelectUnitCommand.SelectedUnit.Position.XPosition);
            Grid.SetRow(SelectUnitCommand.unitRect, SelectUnitCommand.SelectedUnit.Position.YPosition);
            cgm.DrawUnits();
            if (atk.Defender.LifePoints <= 0)
            {
                cgm.RemoveUnit(atk.Defender);
            }
        }
    }
}