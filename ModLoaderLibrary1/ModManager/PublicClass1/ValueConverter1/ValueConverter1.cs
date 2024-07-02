using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ModLoaderLibrary1.ModManager.PublicClass1
{
    public class IntToVisibility1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility v1 = (parameter?.GetType() == typeof(bool) && (bool)parameter) ? Visibility.Visible : Visibility.Collapsed;
            Visibility v2 = v1 == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            if (!IsNumberic(value?.ToString())) return v1;

            return double.Parse(value.ToString()) == 0 ? v1 : v2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public bool IsNumberic(string s)
        {
            return double.TryParse(s, NumberStyles.Float, NumberFormatInfo.InvariantInfo, out double v);
        }
    }

    public class ActualHeightToCornerRadius1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(double)) return null;

            return new CornerRadius((double)value / 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
