using DataDragon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ItemsViewModel : FilterableViewModelBase<Item>, IItemsViewModel
    {
        private readonly CachingDataDragonClient dataDragonClient;

        public ItemsViewModel(CachingDataDragonClient dataDragonClient)
            : base(nameof(Items))
        {
            this.dataDragonClient = dataDragonClient;
        }

        public IList<Item> Items => FilteredCollection;

        protected override async Task<IList<Item>> LoadList(bool forceReload)
        {
            return await Task.Run(() => dataDragonClient.GetItemsAsync(forceReload));
        }
    }
}
