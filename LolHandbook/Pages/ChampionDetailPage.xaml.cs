using DataDragon;
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

            if (e.Parameter is ChampionBase)
            {
                this.DataContext = ViewModelFactory.CreateChampionDetailViewModel((ChampionBase)e.Parameter);
            }
            else if (e.Parameter is string)
            {
                this.DataContext = ViewModelFactory.CreateChampionDetailViewModel((string)e.Parameter);
            }
        }
    }
}
