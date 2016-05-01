using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : FilterableViewModelBase<ChampionSummary>, IChampionsViewModel
    {
        public ChampionsViewModel(CachingDataDragonClient dataDragonClient)
            : base(nameof(Champions))
        {
            LoadData(dataDragonClient);
        }

        public IList<ChampionSummary> Champions => FilteredCollection;

        private async void LoadData(CachingDataDragonClient dataDragonClient)
        {
            Debug.Write("Fetching champions... ");
            IList<ChampionSummary> champions = await Task.Run(() => dataDragonClient.GetChampionsAsync());
            Debug.WriteLine("Done.");

            base.Collection = champions.OrderBy(c => c.Name).ToList();
        }
    }
}
