using System.Reflection;

namespace LolHandbook.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private readonly Assembly assembly;

        public AboutViewModel()
        {
            this.assembly = GetType().GetTypeInfo().Assembly;
        }

        public string AppName => assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
        public string AppVersion => assembly.GetName().Version.ToString();
        public string Copyright => assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;

        public string RiotNotice => $"{AppName} isn’t endorsed by Riot Games and doesn’t reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc. League of Legends © Riot Games, Inc.";
    }
}
