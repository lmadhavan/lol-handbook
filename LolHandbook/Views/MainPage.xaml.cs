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
using System.Collections.Generic;
using DataDragon;

namespace LolHandbook.Views
{
    public sealed partial class MainPage : Page, ISupportResuming
    {
        private static readonly Entity PlaceholderSearchResult = new Entity { Name = "No results found" };

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

        private void OnSearchTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var text = sender.Text.Trim();
                var results = new List<Entity>();

                if (text.Length > 0)
                {
                    results.AddRange(ChampionsView.Search(text));
                    results.AddRange(ItemsView.Search(text));
                    results.Sort((a, b) => a.Name.CompareTo(b.Name));

                    if (results.Count == 0)
                    {
                        results.Add(PlaceholderSearchResult);
                    }
                }

                sender.ItemsSource = results;
            }
        }

        private void OnSearchSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var entity = args.SelectedItem as Entity;
            sender.Text = (entity == PlaceholderSearchResult) ? "" : entity.Name;
        }

        private void OnSearchQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion is ChampionSummary champion)
            {
                Pivot.SelectedIndex = 0;
                ChampionsView.Select(champion);
            }
            else if (args.ChosenSuggestion is Item item)
            {
                Pivot.SelectedIndex = 1;
                ItemsView.Select(item);
            }
        }
    }
}
