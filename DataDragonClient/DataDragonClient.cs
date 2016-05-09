using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDragon
{
    /// <summary>
    /// Provides a client for accessing the League of Legends Data Dragon service.
    /// </summary>
    public sealed class DataDragonClient : IDisposable
    {
        private readonly JsonHttpClient httpClient;
        private readonly UriBuilderReference uriBuilderReference;

        /// <summary>
        /// Initializes a new instance of DataDragonClient with the specified realm.
        /// The client will use the default language for the specified realm.
        /// </summary>
        /// <param name="realm">A Data Dragon realm code, for example, "na"</param>
        public DataDragonClient(string realm)
            : this(realm, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of DataDragonClient with the specified realm and language.
        /// </summary>
        /// <param name="realm">A Data Dragon realm code, for example, "na"</param>
        /// <param name="language">A Data Dragon language code, for example, "en_US"</param>
        public DataDragonClient(string realm, string language)
        {
            this.httpClient = new JsonHttpClient();
            this.uriBuilderReference = new UriBuilderReference(realm, language);
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

        /// <summary>
        /// Gets the current patch version used by the client.
        /// </summary>
        /// <returns>The current patch version.</returns>
        /// <remarks>
        /// Realm information, including patch version, is cached by the client.
        /// You can call <see cref="InvalidateRealmInfo"/> to force this information to be reloaded.
        /// </remarks>
        public async Task<string> GetPatchVersionAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);
            return uriBuilder.PatchVersion;
        }

        /// <summary>
        /// Gets a dictionary of localized game strings.
        /// </summary>
        /// <returns>A dictionary of localized game strings.</returns>
        public async Task<IDictionary<string, string>> GetLocalizedStringsAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri("language.json");
            return await httpClient.GetDataAsync<string>(uri);
        }

        /// <summary>
        /// Gets summary information about all champions in the game.
        /// </summary>
        /// <returns>A dictionary of <see cref="ChampionSummary"/> objects keyed by champion ID.</returns>
        public async Task<IDictionary<string, ChampionSummary>> GetChampionsAsync()
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

        /// <summary>
        /// Gets detailed information about the specified champion.
        /// </summary>
        /// <param name="id">A champion ID.</param>
        /// <returns>A <see cref="ChampionDetail"/> object describing the specified champion.</returns>
        public async Task<ChampionDetail> GetChampionAsync(string id)
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

        /// <summary>
        /// Gets information about all summoner spells in the game.
        /// </summary>
        /// <returns>A dictionary of <see cref="SummonerSpell"/> objects keyed by summoner spell ID.</returns>
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

        /// <summary>
        /// Gets information about all items in the game.
        /// </summary>
        /// <returns>A dictionary of <see cref="Item"/> objects keyed by item ID.</returns>
        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            UriBuilder uriBuilder = await uriBuilderReference.GetUriBuilderAsync(httpClient);

            Uri uri = uriBuilder.GetDataUri("item.json");
            IDictionary<string, Item> items = await httpClient.GetDataAsync<Item>(uri);

            foreach (Item item in items.Values)
            {
                item.ImageUri = uriBuilder.GetImageUri(item.Image);
            }

            return items;
        }
    }
}
