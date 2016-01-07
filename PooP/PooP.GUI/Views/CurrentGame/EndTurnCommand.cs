using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PooP.GUI.Views.CurrentGame
{
    class EndTurnCommand : ICommand
    {
        private CurrentGameModel cgm;

        public EndTurnCommand(CurrentGameModel cgm)
        {
            this.cgm = cgm;
        }

        public bool CanExecute(object parameter)
        {
            EndTurn et = new EndTurn();
            return et.canDo();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            EndTurn et = new EndTurn();
            et.execute();
            if (EndTurn.winner != null)
            {
                cgm.window.CurrentToFinishedGame();
            }
            ((Label)cgm.page.FindName("RemainingTurns")).Content = "Remaining turns : " + GameBuilder.CURRENTGAME.NumberOfTurns;
            if (GameBuilder.CURRENTGAME.NumberOfTurns == 1)
            {
                ((Label)cgm.page.FindName("EndTurn")).Content = "End game";
            }
            cgm.page.OnReload();
            cgm.PlaceHelp();
        }
    }
}
