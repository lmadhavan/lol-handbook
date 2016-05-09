using LolHandbook.ViewModels.Services;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubItemDetailViewModel : ItemDetailViewModel
    {
        public StubItemDetailViewModel(IDataDragonService dataDragonService) : base(dataDragonService)
        {
            this.Id = "0";
        }
    }
}
