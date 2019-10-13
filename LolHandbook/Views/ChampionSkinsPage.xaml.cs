using DataDragon;
using LolHandbook.ViewModels;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook.Views
{
    public sealed partial class ChampionSkinsPage : Page, ISupportSharing
    {
        public ChampionSkinsPage()
        {
            this.InitializeComponent();
        }

        private ChampionSkinsViewModel ViewModel => DataContext as ChampionSkinsViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is IList<ChampionSkin>)
            {
                ViewModel.Skins = (IList<ChampionSkin>)e.Parameter;
            }
        }

        public void OnDataRequested(DataRequest request)
        {
            request.Data.Properties.Title = ViewModel.CurrentSkinName;
            request.Data.SetWebLink(ViewModel.CurrentSkinUri);

            DataRequestDeferral deferral = request.GetDeferral();

            try
            {
                string filename = ViewModel.CurrentSkinName + ".jpg";
                Uri uri = ViewModel.CurrentSkinUri;

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
