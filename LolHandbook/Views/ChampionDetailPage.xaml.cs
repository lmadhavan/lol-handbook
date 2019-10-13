using DataDragon;
using LolHandbook.ViewModels;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Views
{
    public sealed partial class ChampionDetailPage : Page, ISupportResuming
    {
        private const int LoreCollapsedMaxLines = 1;
        private const int LoreExpandedMaxLines = 999;
        private const string LoreCollapsedButtonText = "More";
        private const string LoreExpandedButtonText = "Less";

        public ChampionDetailPage()
        {
            this.InitializeComponent();
            CollapseLore();
        }

        public ChampionDetailViewModel ViewModel => DataContext as ChampionDetailViewModel;

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
                CollapseLore();
            }
        }

        public async Task Resume()
        {
            await ViewModel.LoadData(false);
        }

        private void OnSkinClicked(object sender, RoutedEventArgs e)
        {
            App.Navigate(typeof(ChampionSkinsPage), ViewModel.Skins, new SlideNavigationTransitionInfo());
        }

        private void OnLoreCollapseClicked(object sender, RoutedEventArgs e)
        {
            if (LoreTextBlock.MaxLines < LoreExpandedMaxLines)
            {
                ExpandLore();
            }
            else
            {
                CollapseLore();
            }
        }

        private void CollapseLore()
        {
            LoreTextBlock.MaxLines = LoreCollapsedMaxLines;
            LoreCollapseButton.Content = LoreCollapsedButtonText;
            ScrollViewer.ChangeView(0, 0, null);
        }

        private void ExpandLore()
        {
            LoreTextBlock.MaxLines = LoreExpandedMaxLines;
            LoreCollapseButton.Content = LoreExpandedButtonText;
        }
    }
}
