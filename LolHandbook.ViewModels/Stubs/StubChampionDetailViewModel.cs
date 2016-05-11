using DataDragon;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionDetailViewModel : ChampionDetailViewModel
    {
        public StubChampionDetailViewModel(IDataDragonClient dataDragonClient) : base(dataDragonClient)
        {
            this.Id = "ID";
        }
    }
}
