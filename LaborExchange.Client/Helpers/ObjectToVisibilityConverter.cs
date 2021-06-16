using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LaborExchange.Client.Helpers
{
    public class ObjectToVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = parameter == null;
            var strait = direction ? Visibility.Visible : Visibility.Collapsed;
            var reverse = direction ? Visibility.Collapsed : Visibility.Visible;
            return value == null? strait: reverse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}