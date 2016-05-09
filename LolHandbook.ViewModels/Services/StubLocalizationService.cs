using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class StubLocalizationService : ILocalizationService
    {
        public async Task LoadData(bool forceReload)
        {
        }

        public string Lookup(string key)
        {
            return key;
        }
    }
}
