﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;


namespace APD.Client.Framework.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime && targetType == typeof(string))
            {
                var dateObject = (DateTime)value;
                var resultString = "Since ";
                resultString += dateObject.ToString("dd MMM yyyy");
                return resultString;
            }
                return "No end-date set or wrong format!";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
