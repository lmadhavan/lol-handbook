using LolHandbook.ViewModels;
using LolHandbook.ViewModels.Services;
using LolHandbook.ViewModels.Stubs;
using Windows.ApplicationModel;

namespace LolHandbook
{
    public class ViewModelLocator
    {
        private readonly bool stub;
        private readonly IDataDragonService dataDragonService;
        private readonly ILocalizationService localizationService;

        public ViewModelLocator()
        {
            if (DesignMode.DesignModeEnabled)
            {
                this.stub = true;
                this.dataDragonService = new StubDataDragonService();
                this.localizationService = new StubLocalizationService();
            }
            else
            {
                this.stub = false;
                this.dataDragonService = DataDragonService.Instance;
                this.localizationService = LocalizationService.Instance;
            }
        }

        public ChampionsViewModel ChampionsViewModel => new ChampionsViewModel(dataDragonService, localizationService);
        public ItemsViewModel ItemsViewModel => new ItemsViewModel(dataDragonService, localizationService);
        public ChampionDetailViewModel ChampionDetailViewModel => stub ? new StubChampionDetailViewModel(dataDragonService) : new ChampionDetailViewModel(dataDragonService);
        public ChampionSkinsViewModel ChampionSkinsViewModel => stub ? new StubChampionSkinsViewModel() : new ChampionSkinsViewModel();
        public ItemDetailViewModel ItemDetailViewModel => stub ? new StubItemDetailViewModel(dataDragonService) : new ItemDetailViewModel(dataDragonService);
    }
}
