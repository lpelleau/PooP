using PooP.GUI.Views.WindowApp;
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

namespace PooP.GUI.Views.SplashScreen
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SplashScreenInterface : Page
    {
        private WindowInterface window;

        public SplashScreenInterface(WindowInterface window)
        {
            InitializeComponent();
            this.window = window;
            KeyDown += new KeyEventHandler(KeyAction);
            MouseDown += new MouseButtonEventHandler(MouseAction);
        }

        private void KeyAction(object sender, KeyEventArgs e)
        {
            PageAction();
        }

        private void MouseAction(object sender, MouseEventArgs e)
        {
            PageAction();
        }

        private void PageAction()
        {
            window.OpenMainMenu();
        }
    }
}
