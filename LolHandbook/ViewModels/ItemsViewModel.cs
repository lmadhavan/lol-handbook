using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ItemsViewModel : FilterableViewModelBase<Item>, IItemsViewModel
    {
        public ItemsViewModel(CachingDataDragonClient dataDragonClient)
            : base(nameof(Items))
        {
            LoadData(dataDragonClient);
        }

        public IList<Item> Items => FilteredCollection;

        private async void LoadData(CachingDataDragonClient dataDragonClient)
        {
            Debug.Write("Fetching items... ");
            IList<Item> items = await Task.Run(() => dataDragonClient.GetItemsAsync());
            Debug.WriteLine("Done.");

            base.Collection = items.OrderBy(i => i.Name).ToList();
        }
    }
}
