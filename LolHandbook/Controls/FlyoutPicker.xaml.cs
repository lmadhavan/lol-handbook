using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Controls
{
    public sealed partial class FlyoutPickerControl : UserControl
    {
        private bool flyoutOpen;

        public FlyoutPickerControl()
        {
            this.InitializeComponent();
            (Content as FrameworkElement).DataContext = this;

            Flyout.Opened += (s, e) => flyoutOpen = true;
            Flyout.Closed += (s, e) => flyoutOpen = false;
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(FlyoutPickerControl), new PropertyMetadata(null));
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(object), typeof(FlyoutPickerControl), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(FlyoutPickerControl), new PropertyMetadata(null));

        public event SelectionChangedEventHandler SelectionChanged;

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * The flyoutOpen check is a workaround for the COMException that is generated
             * when Hide() is called before the flyout has opened. This occurs because
             * SelectionChanged is fired when the list is initially bound.
             */
            if (flyoutOpen)
            {
                Flyout.Hide();
            }

            SelectionChanged?.Invoke(this, e);
        }
    }
}
