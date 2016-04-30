using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class ItemsViewModel : FilterableViewModelBase<Item>, IItemsViewModel
    {
        public ItemsViewModel(DataDragonClient dataDragonClient)
            : base(nameof(Items))
        {
            LoadData(dataDragonClient);
        }

        public IList<Item> Items => FilteredCollection;

        private async void LoadData(DataDragonClient dataDragonClient)
        {
            Debug.Write("Fetching items... ");
            IList<Item> items = await dataDragonClient.GetItemsAsync();
            Debug.WriteLine("Done.");

            base.Collection = items.OrderBy(i => i.Name).ToList();
        }
    }
}
