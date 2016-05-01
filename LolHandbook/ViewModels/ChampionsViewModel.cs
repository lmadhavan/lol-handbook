using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : FilterableViewModelBase<ChampionSummary>, IChampionsViewModel
    {
        private readonly CachingDataDragonClient dataDragonClient;

        public ChampionsViewModel(CachingDataDragonClient dataDragonClient)
            : base(nameof(Champions))
        {
            this.dataDragonClient = dataDragonClient;
        }

        public IList<ChampionSummary> Champions => FilteredCollection;

        protected override async Task<IList<ChampionSummary>> LoadList(bool forceReload)
        {
            Debug.Write("Fetching champions... ");
            IList<ChampionSummary> champions = await Task.Run(() => dataDragonClient.GetChampionsAsync(forceReload));
            Debug.WriteLine("Done.");

            return champions;
        }
    }
}
