using LolHandbook.ViewModels.Services;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionDetailViewModel : ChampionDetailViewModel
    {
        public StubChampionDetailViewModel(IDataDragonService dataDragonService) : base(dataDragonService)
        {
            this.Id = "ID";
        }
    }
}
