using DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class StubDataDragonService : IDataDragonService
    {
        private readonly IDictionary<string, Item> items;

        public StubDataDragonService()
        {
            this.items = new Dictionary<string, Item>();
            items["0"] = new Item
            {
                Name = "Item 0",
                Cost = new ItemCost { Total = 1000 },
                Description = "+100 Attack Damage\n+100 Health",
                Plaintext = "An excellent item",
                Requires = new List<string> { "1" },
                BuildsInto = new List<string> { "2" }
            };
            items["1"] = new Item { Name = "Item 1" };
            items["2"] = new Item { Name = "Item 2" };
        }

        public Task<IDictionary<string, string>> GetLocalizedStringsAsync(bool forceReload)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ChampionSummary>> GetChampionsAsync(bool forceReload)
        {
            throw new NotImplementedException();
        }

        public Task<ChampionDetail> GetChampionAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Item>> GetItemsAsync(bool forceReload)
        {
            return await Task.Run(() => items.Values.ToList());
        }

        public Item GetItem(string id)
        {
            return items[id];
        }
    }
}
