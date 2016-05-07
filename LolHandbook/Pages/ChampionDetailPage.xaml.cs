using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionDetailPage : Page, ISupportResuming
    {
        private IChampionDetailViewModel viewModel;

        public ChampionDetailPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string id = ResolveChampionId(e.Parameter);

            if (viewModel == null || viewModel.Id != id)
            {
                this.viewModel = CreateViewModel(e.Parameter);
                this.DataContext = viewModel;
                ScrollViewer.ScrollToVerticalOffset(0);
            }

            viewModel.LoadData(false);
        }

        private IChampionDetailViewModel CreateViewModel(object parameter)
        {
            if (parameter is ChampionBase)
            {
                return ViewModelFactory.CreateChampionDetailViewModel((ChampionBase)parameter);
            }
            else
            {
                return ViewModelFactory.CreateChampionDetailViewModel(parameter.ToString());
            }
        }

        private string ResolveChampionId(object parameter)
        {
            if (parameter is ChampionBase)
            {
                return ((ChampionBase)parameter).Id;
            }
            else
            {
                return parameter.ToString();
            }
        }

        public void OnResuming()
        {
            viewModel.LoadData(false);
        }

        private void Skin_Click(object sender, RoutedEventArgs e)
        {
            App.Navigate(typeof(ChampionSkinsPage), viewModel.Skins, new SlideNavigationTransitionInfo());
        }
    }
}
