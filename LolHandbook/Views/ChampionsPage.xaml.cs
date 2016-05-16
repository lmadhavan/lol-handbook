using DataDragon;
using LolHandbook.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Views
{
    public sealed partial class ChampionsPage : Page, ISupportResuming
    {
        public ChampionsPage()
        {
            this.InitializeComponent();
            UpdateSelectionMode();
        }

        private ChampionsViewModel ViewModel => DataContext as ChampionsViewModel;

        public void OnResuming()
        {
            ViewModel.LoadData(false);
        }

        public void Refresh()
        {
            ViewModel.LoadData(true);
        }

        private void OnItemClicked(object sender, ItemClickEventArgs e)
        {
            if (!MasterDetailsControl.IsDetailsPaneVisible)
            {
                ChampionSummary summary = (ChampionSummary)e.ClickedItem;
                App.Navigate(typeof(ChampionDetailPage), summary);
            }
        }

        private void OnDetailsPaneVisibilityChanged(object sender, EventArgs e)
        {
            UpdateSelectionMode();
        }

        private void UpdateSelectionMode()
        {
            ChampionsGrid.SelectionMode = MasterDetailsControl.IsDetailsPaneVisible ? ListViewSelectionMode.Single : ListViewSelectionMode.None;
        }
    }
}
