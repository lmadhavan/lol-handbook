using DataDragon;
using LolHandbook.ViewModels;
using LolHandbook.ViewModels.Services;
using LolHandbook.ViewModels.Stubs;
using Windows.ApplicationModel;

namespace LolHandbook
{
    public class ViewModelLocator
    {
        private readonly bool stub;
        private readonly IDataDragonClient dataDragonClient;
        private readonly ILocalizationService localizationService;

        public ViewModelLocator()
        {
            if (DesignMode.DesignModeEnabled)
            {
                this.stub = true;
                this.dataDragonClient = new StubDataDragonClient();
                this.localizationService = new StubLocalizationService();
            }
            else
            {
                this.stub = false;
                this.dataDragonClient = DataDragonService.Instance;
                this.localizationService = LocalizationService.Instance;
            }
        }

        public MainPageViewModel MainPageViewModel => new MainPageViewModel(dataDragonClient);
        public ChampionsViewModel ChampionsViewModel => new ChampionsViewModel(dataDragonClient, localizationService);
        public ItemsViewModel ItemsViewModel => new ItemsViewModel(dataDragonClient, localizationService);
        public ChampionDetailViewModel ChampionDetailViewModel => stub ? new StubChampionDetailViewModel(dataDragonClient) : new ChampionDetailViewModel(dataDragonClient);
        public ChampionSkinsViewModel ChampionSkinsViewModel => stub ? new StubChampionSkinsViewModel() : new ChampionSkinsViewModel();
        public ItemDetailViewModel ItemDetailViewModel => stub ? new StubItemDetailViewModel(dataDragonClient) : new ItemDetailViewModel(dataDragonClient);
        public AboutViewModel AboutViewModel => new AboutViewModel();
    }
}
