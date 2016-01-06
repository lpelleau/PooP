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

namespace PooP.GUI.Views.MainMenu
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenuInterface : Page, PageInterface
    {
        private WindowInterface window;
        public MainMenuInterface(WindowInterface window)
        {
            InitializeComponent();
            DataContext = new MainMenuModel(window, this);
            this.window = window;
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

        private void CircleHoverI(object sender, MouseEventArgs e)
        {
            ((Rectangle)sender).Opacity = 100;
        }

        private void CircleHoverO(object sender, MouseEventArgs e)
        {
            ((Rectangle)sender).Opacity = 0;
        }

        private void SoundClick(object sender, MouseButtonEventArgs e)
        {
            Sound.INSTANCE.ToogleMusic();
            OnReload();
        }

        private void FullscreenClick(object sender, MouseButtonEventArgs e)
        {
            if (window.IsfullScreen())
            {
                ((Image)FindName("FullscreenStyle")).Source = new BitmapImage(new Uri("../../images/pages/expand.png", UriKind.Relative));
                window.SmallScreen();
            }
            else
            {
                ((Image)FindName("FullscreenStyle")).Source = new BitmapImage(new Uri("../../images/pages/contract.png", UriKind.Relative));
                window.FullScreen();
            }
        }

        private void NewGameClick(object sender, MouseButtonEventArgs e)
        {
            window.OpenNewGame();
        }
    }
}
