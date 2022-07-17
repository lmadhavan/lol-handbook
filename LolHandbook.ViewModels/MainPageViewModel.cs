using LolHandbook.DataDragon;
using System;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataDragonClient dataDragonClient;

        public MainPageViewModel(IDataDragonClient dataDragonClient)
        {
            this.dataDragonClient = dataDragonClient;
        }

        public string PatchVersion { get; set; }

        public Uri PatchNotesUri
        {
            get
            {
                return new Uri(PatchNotesUrlFor(PatchVersion));
            }
        }

        public async Task LoadData(bool forceReload)
        {
            if (PatchVersion != null && !forceReload)
            {
                return;
            }

            this.Loading = true;
            this.PatchVersion = await dataDragonClient.GetPatchVersionAsync();
            this.Loading = false;

            RaisePropertyChanged(nameof(PatchVersion));
            RaisePropertyChanged(nameof(PatchNotesUri));
        }

        internal static string PatchNotesUrlFor(string patchVersion)
        {
            if (patchVersion == null)
            {
                return null;
            }

            string[] parts = patchVersion.Split('.');

            if (parts.Length < 2)
            {
                return null;
            }

            return $"https://na.leagueoflegends.com/en-us/news/game-updates/patch-{parts[0]}-{parts[1]}-notes/";
        }
    }
}
