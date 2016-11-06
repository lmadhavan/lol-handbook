using DataDragon;
using LolHandbook.ViewModels;
using System.Threading.Tasks;
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

        public async Task Resume()
        {
            await ViewModel.LoadData(false);
        }

        public async Task Refresh()
        {
            await ViewModel.LoadData(true);
        }

        private void OnItemClicked(object sender, ItemClickEventArgs e)
        {
            ChampionSummary summary = (ChampionSummary)e.ClickedItem;

            if (View.IsDetailsPaneVisible)
            {
                ChampionDetailPage.ViewModel.Summary = summary;
            }
            else
            {
                App.Navigate(typeof(ChampionDetailPage), summary);
            }
        }
    }
}
