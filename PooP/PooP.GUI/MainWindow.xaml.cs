using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace PooP.GUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void LaunchGame(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Launching...");
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

    public class ConvAnd : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool comb = true;
            foreach (object value in values)
                comb = comb && (bool) value;
            return comb;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConvNotEmpty : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((string)value).Equals("");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
