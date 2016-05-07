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
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Item)
            {
                this.DataContext = ViewModelFactory.CreateItemDetailViewModel((Item)e.Parameter);
            }
            else if (e.Parameter is string)
            {
                this.DataContext = ViewModelFactory.CreateItemDetailViewModel((string)e.Parameter);
            }

            ScrollViewer.ScrollToVerticalOffset(0);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Item item = (Item)e.ClickedItem;
            if (item != null)
            {
                this.DataContext = ViewModelFactory.CreateItemDetailViewModel(item);
                ScrollViewer.ScrollToVerticalOffset(0);
            }
        }
    }
}
