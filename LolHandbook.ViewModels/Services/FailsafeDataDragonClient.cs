using DataDragon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    internal sealed class FailsafeDataDragonClient : IDataDragonClient
    {
        private readonly CachingDataDragonClient client;

        internal FailsafeDataDragonClient()
        {
            this.client = new CachingDataDragonClient("na");
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public void InvalidateCache()
        {
            client.InvalidateCache();
        }

        public async Task<string> GetPatchVersionAsync()
        {
            try
            {
                return await client.GetPatchVersionAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetPatchVersionAsync)}: {e}");
                return null;
            }
        }

        public async Task<IDictionary<string, string>> GetLocalizedStringsAsync()
        {
            try
            {
                return await client.GetLocalizedStringsAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetLocalizedStringsAsync)}: {e}");
                return null;
            }
        }

        public async Task<IDictionary<string, ChampionSummary>> GetChampionSummariesAsync()
        {
            try
            {
                return await client.GetChampionSummariesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetChampionSummariesAsync)}: {e}");
                return null;
            }
        }

        public async Task<ChampionDetail> GetChampionDetailAsync(string id)
        {
            try
            {
                return await client.GetChampionDetailAsync(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetChampionDetailAsync)}: {e}");
                return null;
            }
        }

        public async Task<IDictionary<string, SummonerSpell>> GetSummonerSpellsAsync()
        {
            try
            {
                return await client.GetSummonerSpellsAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetSummonerSpellsAsync)}: {e}");
                return null;
            }
        }

        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            try
            {
                return await client.GetItemsAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in {nameof(GetItemsAsync)}: {e}");
                return null;
            }
        }
    }
}
