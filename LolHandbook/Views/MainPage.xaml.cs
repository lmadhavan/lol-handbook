using LolHandbook.BackgroundTasks;
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

        public void Resume()
        {
            LoadData(false);
            ChampionsView.Resume();
            ItemsView.Resume();
        }

        public void Refresh()
        {
            DataDragonService.InvalidateCache();
            LoadData(true);
            ChampionsView.Refresh();
            ItemsView.Refresh();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Resume();
        }

        private async void OnAboutClicked(object sender, RoutedEventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            await dialog.ShowAsync();
        }

        private void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private async void LoadData(bool forceReload)
        {
            await ViewModel.LoadData(forceReload);
            Settings.LastPatchVersion = ViewModel.PatchVersion;
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
