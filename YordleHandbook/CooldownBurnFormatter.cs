using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace YordleHandbook
{
    class CooldownBurnFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return "Cooldown: " + value + " seconds";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
