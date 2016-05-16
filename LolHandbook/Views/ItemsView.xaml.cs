using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Views
{
    public sealed partial class ItemsView : UserControl, ISupportResuming
    {
        public ItemsView()
        {
            this.InitializeComponent();
            UpdateSelectionMode();
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

        private void OnItemClicked(object sender, ItemClickEventArgs e)
        {
            if (!MasterDetailsControl.IsDetailsPaneVisible)
            {
                Item item = (Item)e.ClickedItem;
                App.Navigate(typeof(ItemDetailPage), item);
            }
        }

        private void OnDetailsPaneVisibilityChanged(object sender, System.EventArgs e)
        {
            UpdateSelectionMode();
        }

        private void UpdateSelectionMode()
        {
            ItemsList.SelectionMode = MasterDetailsControl.IsDetailsPaneVisible ? ListViewSelectionMode.Single : ListViewSelectionMode.None;
        }
    }
}
