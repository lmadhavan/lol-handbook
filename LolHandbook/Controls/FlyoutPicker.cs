using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Controls
{
    public sealed class FlyoutPicker : Control
    {
        private Flyout flyout;
        private bool flyoutOpen;

        public FlyoutPicker()
        {
            this.DefaultStyleKey = typeof(FlyoutPicker);
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(FlyoutPicker), new PropertyMetadata(null));
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(object), typeof(FlyoutPicker), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(FlyoutPicker), new PropertyMetadata(null));

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

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.flyout = (Flyout)GetTemplateChild("Flyout");
            flyout.Opened += (s, e) => flyoutOpen = true;
            flyout.Closed += (s, e) => flyoutOpen = false;

            ListBox listBox = (ListBox)GetTemplateChild("ListBox");
            listBox.SelectionChanged += OnSelectionChanged;
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
                flyout.Hide();
            }

            SelectionChanged?.Invoke(this, e);
        }
    }
}
