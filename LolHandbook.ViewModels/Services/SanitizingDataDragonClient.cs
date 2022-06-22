using DataDragon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    internal sealed class SanitizingDataDragonClient : IDataDragonClient
    {
        private readonly IDataDragonClient client;

        public SanitizingDataDragonClient(IDataDragonClient client)
        {
            this.client = client;
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task<ChampionDetail> GetChampionDetailAsync(string id)
        {
            var result = await client.GetChampionDetailAsync(id);
            
            result.Lore = HtmlSanitizer.Sanitize(result.Lore);
            result.Passive.Description = HtmlSanitizer.Sanitize(result.Passive.Description);

            foreach (var spell in result.Spells)
            {
                spell.Description = HtmlSanitizer.Sanitize(spell.Description);
            }

            return result;
        }

        public async Task<IDictionary<string, ChampionSummary>> GetChampionSummariesAsync()
        {
            var result = await client.GetChampionSummariesAsync();

            foreach (var summary in result.Values)
            {
                summary.Blurb = HtmlSanitizer.Sanitize(summary.Blurb);
            }

            return result;
        }

        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            var result = await client.GetItemsAsync();

            foreach (var item in result.Values)
            {
                item.Name = HtmlSanitizer.Sanitize(item.Name);
                item.Description = HtmlSanitizer.Sanitize(item.Description);
                item.Plaintext = HtmlSanitizer.Sanitize(item.Plaintext);
            }

            return result;
        }

        public Task<IDictionary<string, string>> GetLocalizedStringsAsync()
        {
            return client.GetLocalizedStringsAsync();
        }

        public Task<string> GetPatchVersionAsync()
        {
            return client.GetPatchVersionAsync();
        }

        public Task<IDictionary<string, SummonerSpell>> GetSummonerSpellsAsync()
        {
            return client.GetSummonerSpellsAsync();
        }
    }
}
