using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Views
{
    public sealed partial class FilterableView : UserControl
    {
        public FilterableView()
        {
            this.InitializeComponent();
            this.Loaded += OnLoaded;
        }

        public static readonly DependencyProperty FilterLabelProperty = DependencyProperty.Register(nameof(FilterLabel), typeof(string), typeof(FilterableView), new PropertyMetadata(null));
        public static readonly DependencyProperty ListViewProperty = DependencyProperty.Register(nameof(ListView), typeof(ListViewBase), typeof(FilterableView), new PropertyMetadata(null));
        public static readonly DependencyProperty DetailsPaneProperty = DependencyProperty.Register(nameof(DetailsPane), typeof(FrameworkElement), typeof(FilterableView), new PropertyMetadata(null));

        public string FilterLabel
        {
            get { return (string)GetValue(FilterLabelProperty); }
            set { SetValue(FilterLabelProperty, value); }
        }

        public ListViewBase ListView
        {
            get { return (ListViewBase)GetValue(ListViewProperty); }
            set { SetValue(ListViewProperty, value); }
        }

        public FrameworkElement DetailsPane
        {
            get { return (FrameworkElement)GetValue(DetailsPaneProperty); }
            set { SetValue(DetailsPaneProperty, value); }
        }

        public bool IsDetailsPaneVisible => DetailsPanePresenter.Visibility == Visibility.Visible;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ListView?.Focus(FocusState.Programmatic);
        }
    }
}
