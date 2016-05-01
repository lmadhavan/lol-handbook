using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataDragon
{
    public class DataDragonClient : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly UriBuilder uriBuilder;

        public DataDragonClient()
        {
            this.httpClient = new HttpClient();
            this.uriBuilder = new UriBuilder();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        public async Task<IDictionary<string, ChampionSummary>> GetChampionsAsync()
        {
            IDictionary<string, ChampionSummary> champions = await GetDataAsync<ChampionSummary>("champion.json");

            foreach (ChampionSummary champion in champions.Values)
            {
                champion.ImageUri = uriBuilder.GetImageUri(champion.Image);
            }

            return champions;
        }

        public async Task<ChampionDetail> GetChampionAsync(string id)
        {
            IDictionary<string, ChampionDetail> champions = await GetDataAsync<ChampionDetail>($"champion/{id}.json");

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
            IDictionary<string, SummonerSpell> summonerSpells = await GetDataAsync<SummonerSpell>("summoner.json");

            foreach (SummonerSpell summonerSpell in summonerSpells.Values)
            {
                summonerSpell.ImageUri = uriBuilder.GetImageUri(summonerSpell.Image);
            }

            return summonerSpells;
        }

        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            IDictionary<string, Item> items = await GetDataAsync<Item>("item.json");

            foreach (Item item in items.Values)
            {
                item.ImageUri = uriBuilder.GetImageUri(item.Image);
            }

            return items;
        }

        private async Task<IDictionary<string, T>> GetDataAsync<T>(string path)
        {
            Uri uri = uriBuilder.GetDataUri(path);

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            string data = JObject.Parse(content)["data"].ToString();
            return JsonConvert.DeserializeObject<IDictionary<string, T>>(data);
        }
    }
}
