using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionsPage : Page
    {
        private readonly IChampionsViewModel viewModel;

        public ChampionsPage()
        {
            this.InitializeComponent();
            this.viewModel = ViewModelFactory.CreateChampionsViewModel();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.DataContext = viewModel;
        }

        private void TagList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFlyout.Hide();
            viewModel.TagFilter = TagList.SelectedItem as string;
        }
    }
}
