using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using PooP.Core.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PooP.GUI.Views.CurrentGame
{
    class HelpCommand : ICommand
    {
        private CurrentGameModel cgm;
        private Border HelpBorder;

        public HelpCommand(CurrentGameModel cgm)
        {
            this.cgm = cgm;
            HelpBorder = new Border();
            HelpBorder.BorderBrush = Brushes.White;
            HelpBorder.BorderThickness = new Thickness(2);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            int[] moves = GameBuilder.CURRENTGAME.getBestMoves();

            for (int i = 0; i < 3; i++)
            {
                Position givenPosition = new Position(moves[i * 2], moves[i * 2 + 1]);
                // TODO : Place border on map in the givenPosition
                //cgm.map.Children.
            }
        }
    }
}