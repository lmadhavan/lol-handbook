using LolHandbook.DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Views
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

            ScrollViewer.ChangeView(0, 0, null);
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            Item item = (Item)e.ClickedItem;
            ViewModel.Item = item;
            ScrollViewer.ChangeView(0, 0, null);
        }
    }
}
