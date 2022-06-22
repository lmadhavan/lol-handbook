using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class StubLocalizationService : ILocalizationService
    {
        public Task LoadData()
        {
            return Task.CompletedTask;
        }

        public string Lookup(string key)
        {
            return key;
        }
    }
}
