using DataDragon;
using LolHandbook.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionSkinsPage : Page
    {
        private IChampionSkinsViewModel viewModel;

        public ChampionSkinsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.viewModel = new ChampionSkinsViewModel((IList<ChampionSkin>)e.Parameter);
            this.DataContext = viewModel;
        }
    }
}
