using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionsPage : Page
    {
        private readonly IChampionsViewModel viewModel;

        public ChampionsPage()
        {
            this.InitializeComponent();
            this.viewModel = ViewModelFactory.CreateChampionsViewModel();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.DataContext = viewModel;
        }

        private void TagList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFlyout.Hide();
            viewModel.TagFilter = TagList.SelectedItem as string;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChampionSummary summary = (ChampionSummary)e.ClickedItem;
            Frame.Navigate(typeof(ChampionDetailPage), summary.Id);
        }
    }
}
