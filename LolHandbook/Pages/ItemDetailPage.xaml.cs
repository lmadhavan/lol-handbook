using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ItemDetailPage : Page
    {
        public ItemDetailPage()
        {
            this.InitializeComponent();
        }

        public ItemDetailViewModel ViewModel => DataContext as ItemDetailViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Item)
            {
                ViewModel.Item = (Item)e.Parameter;
            }
            else if (e.Parameter is string)
            {
                ViewModel.Id = (string)e.Parameter;
            }

            ScrollViewer.ScrollToVerticalOffset(0);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Item item = (Item)e.ClickedItem;
            if (item != null)
            {
                ViewModel.Item = item;
                ScrollViewer.ScrollToVerticalOffset(0);
            }
        }
    }
}
