using LolHandbook.ViewModels.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            DataDragonService.InvalidateCache();
            ChampionsPage.Refresh();
            ItemsPage.Refresh();
        }
    }
}
