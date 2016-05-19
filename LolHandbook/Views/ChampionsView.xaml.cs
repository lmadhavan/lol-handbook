using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Views
{
    public sealed partial class ChampionsView : UserControl, ISupportResuming
    {
        public ChampionsView()
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

        private void OnItemClicked(object sender, ItemClickEventArgs e)
        {
            if (!View.IsDetailsPaneVisible)
            {
                ChampionSummary summary = (ChampionSummary)e.ClickedItem;
                App.Navigate(typeof(ChampionDetailPage), summary);
            }
        }
    }
}
