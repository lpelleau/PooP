using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Interface
{
    public class MainViewModel
    {
        public string Player1Name
        {
            get;
            set;
        }

        private string player2Name;
        public string Player2Name
        {
            get;
            set { Launch.P2 = _value; }
        }

        public string Player1Race
        {
            get;
            set;
        }

        public string Player2Race
        {
            get;
            set;
        }

        public string Difficulty
        {
            get;
            set;
        }

        public ICommand Launch
        {
            get
            {
                return new LaunchCommand();
            }
        }
    }

    public class LaunchCommand : ICommand
    {
        public string P2;
        public void Execute(Object o)
        {
            MessageBox.Show("abc");

        }

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
