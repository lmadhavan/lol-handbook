using System.Collections.Generic;
using System.Threading.Tasks;
using DataDragon;

namespace LolHandbook.ViewModels.Services
{
    public interface IDataDragonService
    {
        Task<IDictionary<string, string>> GetLocalizedStringsAsync(bool forceReload);
        Task<IList<ChampionSummary>> GetChampionsAsync(bool forceReload);
        Task<ChampionDetail> GetChampionAsync(string id);
        Task<IList<Item>> GetItemsAsync(bool forceReload);
        Item GetItem(string id);
    }
}