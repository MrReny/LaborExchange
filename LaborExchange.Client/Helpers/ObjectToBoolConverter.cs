﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LaborExchange.Client.Helpers
{
    public class ObjectToBoolConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}