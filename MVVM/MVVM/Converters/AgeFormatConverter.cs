using System;
using System.Globalization;
using Xamarin.Forms;

namespace MVVM.Converters
{
    public class AgeFormatConverter : IValueConverter
    {
        // from int to string. Int should be greater than zero
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value > 0)
            {
                return value.ToString();
            }
            return string.Empty;
        }

        // from string to int.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
