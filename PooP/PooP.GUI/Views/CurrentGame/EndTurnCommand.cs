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
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PooP.GUI.Views.CurrentGame
{
    class EndTurnCommand : ICommand
    {
        private CurrentGameModel cgm;
        private Page page;

        public EndTurnCommand(CurrentGameModel cgm, Page page)
        {
            this.cgm = cgm;
            this.page = page;
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

            for (int i = 0; i < 2; i++)
            {
                if (GameBuilder.CURRENTGAME.Players[i] == GameBuilder.CURRENTGAME.getCurrentPlayer())
                {
                    ((Label)page.FindName("NameP" + i)).Background
                        .BeginAnimation(SolidColorBrush.ColorProperty, CurrentGameModel.LastPlayedAnim);
                }
                else
                {
                    ((Label)page.FindName("NameP" + i)).Background
                        .BeginAnimation(SolidColorBrush.ColorProperty, CurrentGameModel.NowPlayingAnim);
                }
            }
        }
    }
}
