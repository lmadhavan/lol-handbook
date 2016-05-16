using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Controls
{
    public sealed partial class MasterDetailsControl : UserControl
    {
        public MasterDetailsControl()
        {
            this.InitializeComponent();
            DetailsPanePresenter.RegisterPropertyChangedCallback(VisibilityProperty, OnDetailsPaneVisibilityChanged);
        }

        public static readonly DependencyProperty MasterPaneProperty = DependencyProperty.Register(nameof(MasterPane), typeof(UIElement), typeof(MasterDetailsControl), new PropertyMetadata(null));
        public static readonly DependencyProperty DetailsPaneProperty = DependencyProperty.Register(nameof(DetailsPane), typeof(UIElement), typeof(MasterDetailsControl), new PropertyMetadata(null));

        public UIElement MasterPane
        {
            get { return (UIElement)GetValue(MasterPaneProperty); }
            set { SetValue(MasterPaneProperty, value); }
        }

        public UIElement DetailsPane
        {
            get { return (UIElement)GetValue(DetailsPaneProperty); }
            set { SetValue(DetailsPaneProperty, value); }
        }

        public bool IsDetailsPaneVisible => DetailsPanePresenter.Visibility == Visibility.Visible;
        public event EventHandler DetailsPaneVisibilityChanged;

        private void OnDetailsPaneVisibilityChanged(DependencyObject sender, DependencyProperty dp)
        {
            DetailsPaneVisibilityChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
