using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Controls;
using PooP.GUI.Views.WindowApp;
using System.Windows.Shapes;
using PooP.GUI.Audio;

namespace PooP.GUI.Views.NewGame
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class NewGameInterface : Page, PageInterface
    {
        private WindowInterface window;
        public NewGameInterface(WindowInterface window)
        {
            InitializeComponent();
            this.window = window;
            DataContext = new NewGameModel(window);
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

    public class NegateBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value.ToString()) == "True") return Boolean.FalseString;
            else return Boolean.TrueString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }

    public class RaceParameter
    {
        public String Name;
        public Object Image;
        public Object TextBox;

        public RaceParameter(string name, Object image, Object tb)
        {
            this.Name = name.Substring(0,name.Length-1);
            this.Image = image;
            this.TextBox = tb;
        }
    }

    public class ParameterRaceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new RaceParameter((string)values[0], values[1], values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
