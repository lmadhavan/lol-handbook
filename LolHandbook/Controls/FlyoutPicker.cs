using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Controls
{
    public sealed class FlyoutPicker : Control
    {
        private Flyout flyout;
        private ListView listView;

        public FlyoutPicker()
        {
            this.DefaultStyleKey = typeof(FlyoutPicker);
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(FlyoutPicker), new PropertyMetadata(null));
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(object), typeof(FlyoutPicker), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(FlyoutPicker), new PropertyMetadata(null));

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
            flyout.Opened += OnFlyoutOpened;

            this.listView = (ListView)GetTemplateChild("ListView");
            listView.ItemClick += OnItemClick;
        }

        private void OnFlyoutOpened(object sender, object e)
        {
            ListViewItem item = (ListViewItem)listView.ContainerFromIndex(listView.SelectedIndex);
            item.Focus(FocusState.Programmatic);
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            flyout.Hide();
            SetValue(SelectedItemProperty, e.ClickedItem);
        }
    }
}
