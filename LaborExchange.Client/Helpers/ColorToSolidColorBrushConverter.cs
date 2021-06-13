using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LaborExchange.Client.Helpers
{
    public class ColorToSolidColorBrushConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((SolidColorBrush)value)?.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
    }
}