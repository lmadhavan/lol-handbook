using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace YordleHandbook.Converters
{
    public class CooldownConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string cooldown = value as string;

            if (string.IsNullOrEmpty(cooldown))
            {
                return null;
            }

            return $"Cooldown: {cooldown} seconds";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
