using DataDragon;
using LolHandbook.ViewModels;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Pages
{
    public sealed partial class ChampionSkinsPage : Page, ISupportSharing
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

        public void OnDataRequested(DataRequest request)
        {
            request.Data.Properties.Title = viewModel.CurrentSkinName;

            DataRequestDeferral deferral = request.GetDeferral();

            try
            {
                string filename = viewModel.CurrentSkinName + ".jpg";
                Uri uri = viewModel.SkinUris[viewModel.CurrentSkinIndex];

                RandomAccessStreamReference streamReference = RandomAccessStreamReference.CreateFromUri(uri);

                request.Data.Properties.Thumbnail = streamReference;
                request.Data.SetBitmap(streamReference);
            }
            finally
            {
                deferral.Complete();
            }
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
    }
}
