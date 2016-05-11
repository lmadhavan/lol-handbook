﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDragon
{
    /// <summary>
    /// Provides a caching implementation of <see cref="IDataDragonClient"/>.
    /// </summary>
    /// <remarks>
    /// This implementation caches all calls except <see cref="GetChampionDetailAsync(string)"/>.
    /// The cache can be invalidated by calling <see cref="InvalidateCache"/>.
    /// </remarks>
    public sealed class CachingDataDragonClient : IDataDragonClient
    {
        private readonly DataDragonClient client;

        private IDictionary<string, string> localizedStrings;
        private IDictionary<string, ChampionSummary> championSummaries;
        private IDictionary<string, SummonerSpell> summonerSpells;
        private IDictionary<string, Item> items;

        /// <summary>
        /// Initializes a new instance of CachingDataDragonClient with the specified realm.
        /// The client will use the default language for the specified realm.
        /// </summary>
        /// <param name="realm">A Data Dragon realm code, for example, "na"</param>
        public CachingDataDragonClient(string realm)
        {
            this.client = new DataDragonClient(realm);
        }

        /// <summary>
        /// Initializes a new instance of CachingDataDragonClient with the specified realm and language.
        /// </summary>
        /// <param name="realm">A Data Dragon realm code, for example, "na"</param>
        /// <param name="language">A Data Dragon language code, for example, "en_US"</param>
        public CachingDataDragonClient(string realm, string language)
        {
            this.client = new DataDragonClient(realm, language);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        /// <summary>
        /// Invalidates any cached information, causing it to be reloaded on the next request.
        /// </summary>
        public void InvalidateCache()
        {
            client.InvalidateRealmInfo();
            this.localizedStrings = null;
            this.championSummaries = null;
            this.summonerSpells = null;
            this.items = null;
        }

        public async Task<string> GetPatchVersionAsync()
        {
            return await client.GetPatchVersionAsync();
        }

        public async Task<IDictionary<string, string>> GetLocalizedStringsAsync()
        {
            IDictionary<string, string> result = this.localizedStrings;

            if (result == null)
            {
                result = await client.GetLocalizedStringsAsync();
                this.localizedStrings = result;
            }

            return result;
        }

        public async Task<IDictionary<string, ChampionSummary>> GetChampionSummariesAsync()
        {
            IDictionary<string, ChampionSummary> result = this.championSummaries;

            if (result == null)
            {
                result = await client.GetChampionSummariesAsync();
                this.championSummaries = result;
            }

            return result;
        }

        public async Task<ChampionDetail> GetChampionDetailAsync(string id)
        {
            return await client.GetChampionDetailAsync(id);
        }

        public async Task<IDictionary<string, SummonerSpell>> GetSummonerSpellsAsync()
        {
            IDictionary<string, SummonerSpell> result = this.summonerSpells;

            if (result == null)
            {
                result = await client.GetSummonerSpellsAsync();
                this.summonerSpells = result;
            }

            return result;
        }

        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            IDictionary<string, Item> result = this.items;

            if (result == null)
            {
                result = await client.GetItemsAsync();
                this.items = result;
            }

            return result;
        }
    }
}
