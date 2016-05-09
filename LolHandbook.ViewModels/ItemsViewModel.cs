using DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ItemsViewModel : FilterableViewModelBase<Item>, IItemsViewModel
    {
        private readonly DataDragonService dataDragonService;

        public ItemsViewModel(DataDragonService dataDragonService, ILocalizationService localizationService)
            : base(localizationService, nameof(Items))
        {
            this.dataDragonService = dataDragonService;
        }

        public IList<Item> Items => FilteredCollection;

        protected override async Task<IList<Item>> LoadList(bool forceReload)
        {
            return await Task.Run(() => dataDragonService.GetItemsAsync(forceReload));
        }
    }
}
