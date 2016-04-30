using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LolHandbook.Converters
{
    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string str = value as string;
            string format = parameter as string;

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            if (string.IsNullOrEmpty(format))
            {
                return str;
            }

            return string.Format(format, str);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
