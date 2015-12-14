using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.LoadGame
{
    public class LoadGameModel
    {
        private WindowInterface window;

        public LoadGameModel(WindowInterface window)
        {
            this.window = window;
        }

        public ICommand Load
        {
            get
            {
                return new LoadGameCommand(window);
            }
        }
    }
}
