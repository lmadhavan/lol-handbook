using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class SummonerSpellsPage : Page
    {
        public SummonerSpellsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.DataContext = ViewModelFactory.CreateSummonerSpellsViewModel();
        }
    }
}
