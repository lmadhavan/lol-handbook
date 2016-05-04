using DataDragon;
using LolHandbook.ViewModels;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class ItemsPage : Page, ISupportResuming
    {
        private readonly IItemsViewModel viewModel;

        public ItemsPage()
        {
            this.InitializeComponent();

            if (!DesignMode.DesignModeEnabled)
            {
                this.viewModel = ViewModelFactory.CreateItemsViewModel();
                viewModel.LoadData(false);
                this.DataContext = viewModel;
            }
        }

        public void OnResuming()
        {
            viewModel.LoadData(false);
        }

        public void Refresh()
        {
            viewModel.LoadData(true);
        }

        private void TagList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFlyout.Hide();
            viewModel.TagFilter = TagList.SelectedItem as string;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Item item = (Item)e.ClickedItem;
            App.Navigate(typeof(ItemDetailPage), item);
        }
    }
}
