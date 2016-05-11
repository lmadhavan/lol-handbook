using DataDragon;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubItemDetailViewModel : ItemDetailViewModel
    {
        public StubItemDetailViewModel(IDataDragonClient dataDragonClient) : base(dataDragonClient)
        {
            this.Id = "0";
        }
    }
}
