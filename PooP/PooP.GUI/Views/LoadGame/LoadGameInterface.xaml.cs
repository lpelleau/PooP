using PooP.GUI.Audio;
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

namespace PooP.GUI.Views.LoadGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoadGameInterface : Page, PageInterface
    {
        private WindowInterface window;

        public LoadGameInterface(WindowInterface window)
        {
            InitializeComponent();
            this.window = window;
            DataContext = new LoadGameModel(window, this);
            ((ListBox)FindName("files")).ItemsSource = SaveChoser.INSTANCE.getSaves();
            OnReload();
        }

        public void OnReload()
        {
            if (Sound.INSTANCE.isOn())
            {
                ((Image)FindName("MusicOFF")).Visibility = Visibility.Hidden;
            }
            else
            {
                ((Image)FindName("MusicOFF")).Visibility = Visibility.Visible;
            }
        }
    }
}
