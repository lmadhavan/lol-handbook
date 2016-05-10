using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class MainPage : Page, ISupportResuming
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void OnResuming()
        {
            ChampionsPage.OnResuming();
            ItemsPage.OnResuming();
        }

        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            ChampionsPage.Refresh();
            ItemsPage.Refresh();
        }
    }
}
