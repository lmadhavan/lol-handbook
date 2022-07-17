using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.DataDragon
{
    /// <summary>
    /// Provides a default implementation of <see cref="IDataDragonClient"/>.
    /// </summary>
    public sealed class DataDragonClient : IDataDragonClient
    {
        private readonly JsonHttpClient httpClient;
        private readonly UriBuilderReference uriBuilderReference;

        /// <summary>
        /// Initializes a new instance of DataDragonClient with the specified realm.
        /// </summary>
        /// <param name="realm">A Data Dragon realm code, for example, "na"</param>
        /// <remarks>The client will use the default language and latest patch version for the specified realm.</remarks>
        public DataDragonClient(string realm)
            : this(new RealmConfiguration(realm))
        {
        }

        /// <summary>
        /// Initializes a new instance of DataDragonClient with the specified realm configuration.
        /// </summary>
        /// <param name="realmConfiguration">A <see cref="RealmConfiguration"/> object that specifies configuration parameters for the client.</param>
        public DataDragonClient(RealmConfiguration realmConfiguration)
        {
            this.httpClient = new JsonHttpClient();
            this.uriBuilderReference = new UriBuilderReference(realmConfiguration);
        }

        public void Dispose()
        {
            uriBuilderReference.Dispose();
            httpClient.Dispose();
        }

        /// <summary>
        /// Invalidates any cached realm information, causing it to be reloaded on the next request.
        /// </summary>
        public void InvalidateRealmInfo()
        {
            uriBuilderReference.Reset();
        }

        public async Task<string> GetPatchVersionAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);
            return uriBuilder.PatchVersion;
        }

        public async Task<IDictionary<string, string>> GetLocalizedStringsAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri("language.json");
            return await httpClient.GetDataAsync<string>(uri);
        }

        public async Task<IDictionary<string, ChampionSummary>> GetChampionSummariesAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri("champion.json");
            IDictionary<string, ChampionSummary> champions = await httpClient.GetDataAsync<ChampionSummary>(uri);

            foreach (ChampionSummary champion in champions.Values)
            {
                champion.ImageUri = uriBuilder.GetImageUri(champion.Image);
            }

            return champions;
        }

        public async Task<ChampionDetail> GetChampionDetailAsync(string id)
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri($"champion/{id}.json");
            IDictionary<string, ChampionDetail> champions = await httpClient.GetDataAsync<ChampionDetail>(uri);

            ChampionDetail champion = champions[id];
            champion.ImageUri = uriBuilder.GetImageUri(champion.Image);
            champion.Passive.ImageUri = uriBuilder.GetImageUri(champion.Passive.Image);

            foreach (ChampionSpell spell in champion.Spells)
            {
                spell.ImageUri = uriBuilder.GetImageUri(spell.Image);
            }

            foreach (ChampionSkin skin in champion.Skins)
            {
                skin.ImageUri = uriBuilder.GetSkinUri(id, skin.Num);
            }

            return champion;
        }

        public async Task<IDictionary<string, SummonerSpell>> GetSummonerSpellsAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri("summoner.json");
            IDictionary<string, SummonerSpell> summonerSpells = await httpClient.GetDataAsync<SummonerSpell>(uri);

            foreach (SummonerSpell summonerSpell in summonerSpells.Values)
            {
                summonerSpell.ImageUri = uriBuilder.GetImageUri(summonerSpell.Image);
            }

            return summonerSpells;
        }

        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri("item.json");
            IDictionary<string, Item> items = await httpClient.GetDataAsync<Item>(uri);

            foreach (Item item in items.Values)
            {
                item.ImageUri = uriBuilder.GetImageUri(item.Image);
                item.EnabledMaps = new HashSet<string>(item.Maps.Keys.Where(mapId => item.Maps[mapId] == true));
            }

            return items;
        }
    }
}
