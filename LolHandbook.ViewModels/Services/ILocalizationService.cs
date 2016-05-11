using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public interface ILocalizationService
    {
        Task LoadData();
        string Lookup(string key);
    }
}