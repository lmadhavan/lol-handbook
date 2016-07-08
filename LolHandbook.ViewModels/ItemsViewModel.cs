using DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ItemsViewModel : FilterableViewModelBase<Item>
    {
        private readonly IDataDragonClient dataDragonClient;

        public ItemsViewModel(IDataDragonClient dataDragonClient, ILocalizationService localizationService)
            : base(localizationService, nameof(ItemGroups))
        {
            this.dataDragonClient = dataDragonClient;
        }

        public IEnumerable<IGrouping<string, Item>> ItemGroups => FilteredGroups;

        protected override async Task<IList<Item>> LoadList()
        {
            IDictionary<string, Item> result = await Task.Run(() => dataDragonClient.GetItemsAsync());
            return result.Values.ToList();
        }
    }
}
