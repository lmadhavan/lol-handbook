using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public interface ILocalizationService
    {
        Task LoadData(bool forceReload);
        string Lookup(string key);
    }
}