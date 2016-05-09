using DataDragon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class DataDragonService
    {
        private static DataDragonService instance;

        private readonly DataDragonClient client;
        private IDictionary<string, string> localizedStrings;
        private IDictionary<string, ChampionSummary> champions;
        private IDictionary<string, Item> items;

        private DataDragonService()
        {
            this.client = new DataDragonClient("na");
        }

        public static DataDragonService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataDragonService();
                }

                return instance;
            }
        }

        public async Task<IDictionary<string, string>> GetLocalizedStringsAsync(bool forceReload)
        {
            if (localizedStrings == null || forceReload)
            {
                try
                {
                    this.localizedStrings = await client.GetLocalizedStringsAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Exception in {nameof(GetLocalizedStringsAsync)}: {e}");
                    return null;
                }
            }

            return localizedStrings;
        }

        public async Task<IList<ChampionSummary>> GetChampionsAsync(bool forceReload)
        {
            if (champions == null || forceReload)
            {
                try
                {
                    this.champions = await client.GetChampionsAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Exception in {nameof(GetChampionsAsync)}: {e}");
                    return null;
                }
            }

            return champions.Values.ToList();
        }

        public async Task<ChampionDetail> GetChampionAsync(string id)
        {
            try
            {
                return await client.GetChampionAsync(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetChampionAsync)}: {e}");
                return null;
            }
        }

        public async Task<IList<Item>> GetItemsAsync(bool forceReload)
        {
            if (items == null || forceReload)
            {
                try
                {
                    this.items = await client.GetItemsAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Exception in {nameof(GetItemsAsync)}: {e}");
                    return null;
                }
            }

            return items.Values.ToList();
        }

        public Item GetItem(string id)
        {
            if (items == null)
            {
                Debug.WriteLine($"Call to {nameof(GetItem)} before items have been loaded");
                return null;
            }

            if (!items.ContainsKey(id))
            {
                Debug.WriteLine($"Call to {nameof(GetItem)} with invalid item ID {id}");
                return null;
            }

            return items[id];
        }
    }
}
