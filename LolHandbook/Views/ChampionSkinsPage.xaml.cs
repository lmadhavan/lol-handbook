using DataDragon;
using LolHandbook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System.UserProfile;
using Windows.UI.Popups;
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
        private bool IsWallpaperSupported => UserProfilePersonalizationSettings.IsSupported();

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
                RandomAccessStreamReference streamReference = RandomAccessStreamReference.CreateFromUri(ViewModel.CurrentSkinUri);

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

        private async void SetWallpaper_Click(object sender, RoutedEventArgs e)
        {
            string filename = ViewModel.CurrentSkinUri.Segments.Last();
            StorageFile streamedFile = await StorageFile.CreateStreamedFileFromUriAsync(filename, ViewModel.CurrentSkinUri, null);
            StorageFile localFile = await streamedFile.CopyAsync(ApplicationData.Current.LocalFolder, filename, NameCollisionOption.ReplaceExisting);

            bool succeeded = await UserProfilePersonalizationSettings.Current.TrySetWallpaperImageAsync(localFile);

            MessageDialog dialog = new MessageDialog(succeeded ? "Desktop background set successfully." : "Unable to set desktop background.");
            await dialog.ShowAsync();
        }
    }
}
