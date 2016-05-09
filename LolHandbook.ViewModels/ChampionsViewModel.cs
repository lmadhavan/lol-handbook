using DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : FilterableViewModelBase<ChampionSummary>, IChampionsViewModel
    {
        private readonly DataDragonService dataDragonService;

        public ChampionsViewModel(DataDragonService dataDragonService, ILocalizationService localizationService)
            : base(localizationService, nameof(Champions))
        {
            this.dataDragonService = dataDragonService;
        }

        public IList<ChampionSummary> Champions => FilteredCollection;

        protected override async Task<IList<ChampionSummary>> LoadList(bool forceReload)
        {
            return await Task.Run(() => dataDragonService.GetChampionsAsync(forceReload));
        }
    }
}
