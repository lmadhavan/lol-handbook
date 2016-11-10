using LolHandbook.BackgroundTasks;
using LolHandbook.ViewModels;
using LolHandbook.ViewModels.Services;
using System;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;

namespace LolHandbook.Views
{
    public sealed partial class MainPage : Page, ISupportResuming
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        public async Task Resume()
        {
            await LoadData(false);
            await ChampionsView.Resume();
            await ItemsView.Resume();
        }

        public async Task Refresh()
        {
            DataDragonService.InvalidateCache();
            await LoadData(true);
            await ChampionsView.Refresh();
            await ItemsView.Refresh();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await Resume();
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.GamepadLeftShoulder || e.Key == VirtualKey.GamepadRightShoulder)
            {
                Pivot.SelectedIndex = (Pivot.SelectedIndex + 1) % 2;
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        private async void OnAboutClicked(object sender, RoutedEventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            await dialog.ShowAsync();
        }

        private async void OnRefreshClicked(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        private async Task LoadData(bool forceReload)
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
