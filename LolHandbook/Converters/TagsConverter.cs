using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LolHandbook.Converters
{
    public class TagsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IList<string> tags = value as IList<string>;

            if (tags == null)
            {
                return null;
            }

            return "Role: " + string.Join(", ", tags);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
