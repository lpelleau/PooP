using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.Credits
{
    public class CreditsModel
    {
        public WindowInterface window;

        public CreditsModel(WindowInterface window)
        {
            this.window = window;
        }

        public ICommand Back
        {
            get
            {
                return new BackCommand(window);
            }
        }
    }
}
