using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Input;

namespace PooP.GUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        public RaceParameter(string name, Object image)
        {
            this.Name = name.Substring(0,name.Length-1);
            this.Image = image;
        }
    }

    public class ParameterRaceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new RaceParameter((string)values[0], values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
