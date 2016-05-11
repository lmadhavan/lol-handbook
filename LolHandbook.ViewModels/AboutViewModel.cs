using DataDragon;
using System.Reflection;

namespace LolHandbook.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private readonly IDataDragonClient dataDragonClient;
        private readonly Assembly assembly;

        public AboutViewModel(IDataDragonClient dataDragonClient)
        {
            this.dataDragonClient = dataDragonClient;
            this.assembly = GetType().GetTypeInfo().Assembly;
            LoadData();
        }

        public string AppVersion => $"{Product} {Version}";
        private string Product => assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
        private string Version => assembly.GetName().Version.ToString();
        public string Copyright => assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;

        public string PatchVersion { get; private set; } = "???";

        public string RiotNotice => $"{Product} isn’t endorsed by Riot Games and doesn’t reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc. League of Legends © Riot Games, Inc.";

        private async void LoadData()
        {
            this.PatchVersion = await dataDragonClient.GetPatchVersionAsync();
            RaisePropertyChanged(nameof(PatchVersion));
        }
    }
}
