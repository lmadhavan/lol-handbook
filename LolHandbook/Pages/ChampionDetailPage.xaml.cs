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

        public void OnResuming()
        {
            if (viewModel != null)
            {
                viewModel.LoadData(false);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is ChampionBase)
            {
                viewModel = ViewModelFactory.CreateChampionDetailViewModel((ChampionBase)e.Parameter);
            }
            else if (e.Parameter is string)
            {
                viewModel = ViewModelFactory.CreateChampionDetailViewModel((string)e.Parameter);
            }

            if (viewModel != null)
            {
                viewModel.LoadData(false);
                this.DataContext = viewModel;
            }
        }
    }
}
