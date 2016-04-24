using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using YordleHandbook.ViewModels;

namespace YordleHandbook
{
    public sealed partial class SummonerSpellPage : Page
    {
        private readonly SummonerSpellsViewModel viewModel;

        public SummonerSpellPage()
        {
            this.InitializeComponent();
            this.viewModel = new SummonerSpellsViewModel();
            this.DataContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            viewModel.Load();
        }
    }
}
