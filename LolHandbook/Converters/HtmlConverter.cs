using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LolHandbook.Converters
{
    public class HtmlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string html = value as string;

            if (string.IsNullOrEmpty(html))
            {
                return null;
            }

            return html.Replace("<br>", "\n");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
