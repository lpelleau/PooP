using PooP.GUI.Views.MainWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PooP.GUI.Views.CurrentGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CurrentGameInterface : Page
    {
        private MainWindowInterface window;
        public CurrentGameInterface(MainWindowInterface window)
        {
            InitializeComponent();
            this.window = window;
        }
    }
}
