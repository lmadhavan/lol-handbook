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

        public ViewModelLocator()
        {
            if (DesignMode.DesignModeEnabled)
            {
                this.stub = true;
                this.dataDragonService = new StubDataDragonService();
            }
            else
            {
                this.stub = false;
                this.dataDragonService = DataDragonService.Instance;
            }
        }

        public ChampionDetailViewModel ChampionDetailViewModel => stub ? new StubChampionDetailViewModel(dataDragonService) : new ChampionDetailViewModel(dataDragonService);
        public ItemDetailViewModel ItemDetailViewModel => stub ? new StubItemDetailViewModel(dataDragonService) : new ItemDetailViewModel(dataDragonService);
    }
}
