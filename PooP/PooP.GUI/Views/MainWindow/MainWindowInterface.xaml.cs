using PooP.GUI.Views.MainMenu;
using PooP.GUI.Views.NewGame;
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

namespace PooP.GUI.Views.MainWindow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindowInterface : Window
    {
        private Page mainMenu;
        public MainWindowInterface()
        {
            InitializeComponent();

            mainMenu = new MainMenuInterface(this);
            frame.Content = mainMenu;
        }
    }
}
