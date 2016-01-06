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
using System.Windows.Shapes;

namespace PooP.GUI.Views.CurrentGame
{
    class RedoCommand : ICommand
    {
        private CurrentGameInterface page;

        public RedoCommand(CurrentGameInterface page)
        {
            this.page = page;
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
            UndoableImpl.redo();
            ((CurrentGameModel)page.DataContext).DrawUnits();
            page.OnReload();
        }
    }
}