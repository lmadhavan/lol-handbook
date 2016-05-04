using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionDetailPage : Page, ISupportResuming
    {
        private IChampionDetailViewModel viewModel;

        public ChampionDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is ChampionBase)
            {
                viewModel = ViewModelFactory.CreateChampionDetailViewModel((ChampionBase)e.Parameter);
            }
            else
            {
                viewModel = ViewModelFactory.CreateChampionDetailViewModel(e.Parameter.ToString());
            }

            viewModel.LoadData(false);
            this.DataContext = viewModel;
        }

        public void OnResuming()
        {
            viewModel.LoadData(false);
        }
    }
}
