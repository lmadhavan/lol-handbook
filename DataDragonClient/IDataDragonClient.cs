using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDragon
{
    /// <summary>
    /// Provides a client for accessing the League of Legends Data Dragon service.
    /// </summary>
    public interface IDataDragonClient : IDisposable
    {
        /// <summary>
        /// Gets the current patch version used by the client.
        /// </summary>
        /// <returns>The current patch version.</returns>
        Task<string> GetPatchVersionAsync();

        /// <summary>
        /// Gets a dictionary of localized game strings.
        /// </summary>
        /// <returns>A dictionary of localized game strings.</returns>
        Task<IDictionary<string, string>> GetLocalizedStringsAsync();

        /// <summary>
        /// Gets summary information about all champions in the game.
        /// </summary>
        /// <returns>A dictionary of <see cref="ChampionSummary"/> objects keyed by champion ID.</returns>
        Task<IDictionary<string, ChampionSummary>> GetChampionSummariesAsync();

        /// <summary>
        /// Gets detailed information about the specified champion.
        /// </summary>
        /// <param name="id">A champion ID.</param>
        /// <returns>A <see cref="ChampionDetail"/> object describing the specified champion.</returns>
        Task<ChampionDetail> GetChampionDetailAsync(string id);

        /// <summary>
        /// Gets information about all summoner spells in the game.
        /// </summary>
        /// <returns>A dictionary of <see cref="SummonerSpell"/> objects keyed by summoner spell ID.</returns>
        Task<IDictionary<string, SummonerSpell>> GetSummonerSpellsAsync();

        /// <summary>
        /// Gets information about all items in the game.
        /// </summary>
        /// <returns>A dictionary of <see cref="Item"/> objects keyed by item ID.</returns>
        Task<IDictionary<string, Item>> GetItemsAsync();
    }
}