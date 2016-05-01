using DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class CachingDataDragonClient
    {
        private readonly DataDragonClient client;
        private IDictionary<string, ChampionSummary> champions;
        private IDictionary<string, Item> items;

        public CachingDataDragonClient()
        {
            this.client = new DataDragonClient();
        }

        public async Task<IList<ChampionSummary>> GetChampionsAsync()
        {
            if (champions == null)
            {
                this.champions = await client.GetChampionsAsync();
            }

            return champions.Values.ToList();
        }

        public async Task<ChampionDetail> GetChampionAsync(string id)
        {
            return await client.GetChampionAsync(id);
        }

        public async Task<IList<Item>> GetItemsAsync()
        {
            if (items == null)
            {
                this.items = await client.GetItemsAsync();
            }

            return items.Values.ToList();
        }

        public Item GetItem(string id)
        {
            if (items == null)
            {
                throw new InvalidOperationException();
            }

            if (items.ContainsKey(id))
            {
                return items[id];
            }

            return null;
        }
    }
}
