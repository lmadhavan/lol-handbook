using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Controls
{
    public sealed partial class MasterDetailsControl : UserControl
    {
        public MasterDetailsControl()
        {
            this.InitializeComponent();

            UpdateDetailsPaneVisible();
            DetailsPanePresenter.RegisterPropertyChangedCallback(VisibilityProperty, OnDetailsPaneVisibilityChanged);
        }

        public static DependencyProperty MasterPaneProperty = DependencyProperty.Register(nameof(MasterPane), typeof(UIElement), typeof(MasterDetailsControl), new PropertyMetadata(null));
        public static DependencyProperty DetailsPaneProperty = DependencyProperty.Register(nameof(DetailsPane), typeof(UIElement), typeof(MasterDetailsControl), new PropertyMetadata(null));
        public static DependencyProperty IsDetailsPaneVisibleProperty = DependencyProperty.Register(nameof(IsDetailsPaneVisible), typeof(bool), typeof(MasterDetailsControl), new PropertyMetadata(false));

        public UIElement MasterPane
        {
            get
            {
                return (UIElement)GetValue(MasterPaneProperty);
            }

            set
            {
                SetValue(MasterPaneProperty, value);
                MasterPanePresenter.Content = value;
            }
        }

        public UIElement DetailsPane
        {
            get
            {
                return (UIElement)GetValue(DetailsPaneProperty);
            }

            set
            {
                SetValue(DetailsPaneProperty, value);
                DetailsPanePresenter.Content = value;
            }
        }

        public bool IsDetailsPaneVisible
        {
            get
            {
                return (bool)GetValue(IsDetailsPaneVisibleProperty);
            }
        }

        private void OnDetailsPaneVisibilityChanged(DependencyObject sender, DependencyProperty dp)
        {
            UpdateDetailsPaneVisible();
        }

        private void UpdateDetailsPaneVisible()
        {
            SetValue(IsDetailsPaneVisibleProperty, DetailsPanePresenter.Visibility == Visibility.Visible);
        }
    }
}
