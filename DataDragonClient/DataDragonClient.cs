using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<SummonerSpell>> GetSummonerSpellsAsync()
        {
            IList<SummonerSpell> summonerSpells = await GetDataAsync<SummonerSpell>("summoner.json");

            foreach (SummonerSpell summonerSpell in summonerSpells)
            {
                summonerSpell.ImageUri = uriBuilder.GetImageUri(summonerSpell.Image);
            }

            return summonerSpells;
        }

        private async Task<IList<T>> GetDataAsync<T>(string path)
        {
            Uri uri = uriBuilder.GetDataUri(path);

            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            string data = JObject.Parse(content)["data"].ToString();
            IDictionary<string, T> entries = JsonConvert.DeserializeObject<IDictionary<string, T>>(data);

            return entries.Values.ToList();
        }
    }
}
