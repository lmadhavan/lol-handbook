using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : FilterableViewModelBase<ChampionSummary>, IChampionsViewModel
    {
        public ChampionsViewModel(DataDragonClient dataDragonClient)
            : base(nameof(Champions))
        {
            LoadData(dataDragonClient);
        }

        public IList<ChampionSummary> Champions => FilteredCollection;

        private async void LoadData(DataDragonClient dataDragonClient)
        {
            Debug.Write("Fetching champions... ");
            IList<ChampionSummary> champions = await dataDragonClient.GetChampionsAsync();
            Debug.WriteLine("Done.");

            base.Collection = champions.OrderBy(c => c.Name).ToList();
        }
    }
}
