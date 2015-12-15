using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PooP.GUI.Views.Tutorial
{
    public abstract class TipsCommand : ICommand
    {
        protected TutorialInterface page;

        protected static int currentTip = 0;

        public TipsCommand(TutorialInterface page)
        {
            this.page = page;
        }

        public abstract void Execute(Object o);

        public bool CanExecute(Object o)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
