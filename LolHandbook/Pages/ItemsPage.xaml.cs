using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class ItemsPage : Page, ISupportResuming
    {
        public ItemsPage()
        {
            this.InitializeComponent();
        }

        private ItemsViewModel ViewModel => DataContext as ItemsViewModel;

        public void OnResuming()
        {
            ViewModel.LoadData(false);
        }

        public void Refresh()
        {
            ViewModel.LoadData(true);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!MasterDetailsControl.IsDetailsPaneVisible)
            {
                Item item = (Item)e.ClickedItem;
                App.Navigate(typeof(ItemDetailPage), item);
            }
        }
    }
}
