using DataDragon;
using LolHandbook.ViewModels.Services;

namespace LolHandbook.ViewModels
{
    public sealed class ViewModelFactory
    {
        public static IChampionsViewModel CreateChampionsViewModel()
        {
            return new ChampionsViewModel(DataDragonService.Instance, LocalizationService.Instance);
        }

        public static IItemsViewModel CreateItemsViewModel()
        {
            return new ItemsViewModel(DataDragonService.Instance, LocalizationService.Instance);
        }
    }
}
