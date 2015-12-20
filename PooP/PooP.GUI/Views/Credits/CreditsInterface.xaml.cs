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

namespace PooP.GUI.Views.Credits
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreditsInterface : Page
    {
        private WindowInterface window;
        public CreditsInterface(WindowInterface window)
        {
            InitializeComponent();
            DataContext = new CreditsModel(window);
            this.window = window;
        }

        private void SoundHoverI(object sender, MouseEventArgs e)
        {
            ((Rectangle)sender).Opacity = 100;
        }

        private void SoundHoverO(object sender, MouseEventArgs e)
        {
            ((Rectangle)sender).Opacity = 0;
        }

        private void SoundClick(object sender, MouseButtonEventArgs e)
        {
            Sound.INSTANCE.ToogleMusic();
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
