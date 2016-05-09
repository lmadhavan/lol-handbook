using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionDetailPage : Page, ISupportResuming
    {
        public ChampionDetailPage()
        {
            this.InitializeComponent();
        }

        private ChampionDetailViewModel ViewModel => DataContext as ChampionDetailViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is ChampionSummary)
            {
                ViewModel.Summary = (ChampionSummary)e.Parameter;
            }
            else if (e.Parameter is string)
            {
                ViewModel.Id = (string)e.Parameter;
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                ScrollViewer.ScrollToVerticalOffset(0);
            }
        }

        public void OnResuming()
        {
            ViewModel.LoadData(false);
        }

        private void Skin_Click(object sender, RoutedEventArgs e)
        {
            App.Navigate(typeof(ChampionSkinsPage), ViewModel.Skins, new SlideNavigationTransitionInfo());
        }
    }
}
