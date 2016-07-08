using DataDragon;
using System;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private const string PatchVersionPlaceholder = "???";

        private readonly IDataDragonClient dataDragonClient;

        public MainPageViewModel(IDataDragonClient dataDragonClient)
        {
            this.dataDragonClient = dataDragonClient;
        }

        public string PatchVersion { get; private set; } = PatchVersionPlaceholder;

        public Uri PatchNotesUri
        {
            get
            {
                string patchNotesVersion = FormatPatchNotesVersion(PatchVersion);
                return new Uri($"http://na.leagueoflegends.com/en/news/game-updates/patch/patch-{patchNotesVersion}-notes");
            }
        }

        public async Task LoadData(bool forceReload)
        {
            if (PatchVersion != PatchVersionPlaceholder && !forceReload)
            {
                return;
            }

            this.Loading = true;
            this.PatchVersion = await dataDragonClient.GetPatchVersionAsync();
            this.Loading = false;

            RaisePropertyChanged(nameof(PatchVersion));
            RaisePropertyChanged(nameof(PatchNotesUri));
        }

        internal static string FormatPatchNotesVersion(string patchVersion)
        {
            string[] parts = patchVersion.Split('.');
            
            switch (parts.Length)
            {
                case 0:
                    return "";

                case 1:
                    return parts[0];

                default:
                    return parts[0] + parts[1];
            }
        }
    }
}
