using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using PooP.Core.Ressource;
using PooP.GUI.Views.WindowApp;
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
    class TutorialCommand : ICommand
    {
        private WindowInterface window;

        public TutorialCommand(WindowInterface window)
        {
            this.window = window;
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
            window.OpenTutorial();
        }
    }
}