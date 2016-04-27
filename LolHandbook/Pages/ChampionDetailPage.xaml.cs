using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionDetailPage : Page
    {
        public ChampionDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string id = e.Parameter as string;
            this.DataContext = ViewModelFactory.CreateChampionDetailViewModel(id);
        }
    }
}
