using DataDragon;
using LolHandbook.ViewModels;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Views
{
    public sealed partial class ItemsView : UserControl, ISupportResuming
    {
        public ItemsView()
        {
            this.InitializeComponent();
        }

        private ItemsViewModel ViewModel => DataContext as ItemsViewModel;

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
            if (!View.IsDetailsPaneVisible)
            {
                Item item = (Item)e.ClickedItem;
                App.Navigate(typeof(ItemDetailPage), item);
            }
        }
    }
}
