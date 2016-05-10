using DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : FilterableViewModelBase<ChampionSummary>
    {
        private readonly IDataDragonService dataDragonService;

        public ChampionsViewModel(IDataDragonService dataDragonService, ILocalizationService localizationService)
            : base(localizationService, nameof(Champions))
        {
            this.dataDragonService = dataDragonService;
            LoadData(false);
        }

        public IList<ChampionSummary> Champions => FilteredCollection;

        protected override async Task<IList<ChampionSummary>> LoadList(bool forceReload)
        {
            return await Task.Run(() => dataDragonService.GetChampionsAsync(forceReload));
        }
    }
}
