using LolHandbook.ViewModels;
using LolHandbook.ViewModels.Services;
using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Views
{
    public sealed partial class MainPage : Page, ISupportResuming
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        public void OnResuming()
        {
            LoadData(false);
            ChampionsView.OnResuming();
            ItemsView.OnResuming();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            OnResuming();
        }

        private async void OnAboutClicked(object sender, RoutedEventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            await dialog.ShowAsync();
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            DataDragonService.InvalidateCache();
            LoadData(true);
            ChampionsView.Refresh();
            ItemsView.Refresh();
        }

        private async void LoadData(bool forceReload)
        {
            await ViewModel.LoadData(forceReload);
        }

        private async void OnPatchNotesClicked(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.Loading)
            {
                await Launcher.LaunchUriAsync(ViewModel.PatchNotesUri);
            }
        }
    }
}
