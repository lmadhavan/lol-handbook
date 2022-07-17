using LolHandbook.DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : FilterableViewModelBase<ChampionSummary>
    {
        private readonly IDataDragonClient dataDragonClient;

        public ChampionsViewModel(IDataDragonClient dataDragonClient, ILocalizationService localizationService)
            : base(localizationService, nameof(ChampionGroups))
        {
            this.dataDragonClient = dataDragonClient;
        }

        public IEnumerable<IGrouping<string, ChampionSummary>> ChampionGroups => FilteredGroups;

        protected override async Task<IList<ChampionSummary>> LoadList()
        {
            IDictionary<string, ChampionSummary> result = await Task.Run(() => dataDragonClient.GetChampionSummariesAsync());
            return result.Values.ToList();
        }
    }
}
