using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionsPage : Page, ISupportResuming
    {
        public ChampionsPage()
        {
            this.InitializeComponent();
        }

        private ChampionsViewModel ViewModel => DataContext as ChampionsViewModel;

        public void OnResuming()
        {
            ViewModel.LoadData(false);
        }

        public void Refresh()
        {
            ViewModel.LoadData(true);
        }

        private void TagList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFlyout.Hide();
            ViewModel.TagFilter = TagList.SelectedItem as Tag;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChampionSummary summary = (ChampionSummary)e.ClickedItem;
            App.Navigate(typeof(ChampionDetailPage), summary);
        }
    }
}
