using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LolHandbook.Converters
{
    public class DefaultingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value ?? parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
