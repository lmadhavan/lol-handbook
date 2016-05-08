using DataDragon;

namespace LolHandbook.ViewModels
{
    public sealed class ViewModelFactory
    {
        private static CachingDataDragonClient dataDragonClient;

        private static CachingDataDragonClient DataDragonClient
        {
            get
            {
                if (dataDragonClient == null)
                {
                    dataDragonClient = new CachingDataDragonClient();
                }

                return dataDragonClient;
            }
        }

        public static IChampionsViewModel CreateChampionsViewModel()
        {
            return new ChampionsViewModel(DataDragonClient);
        }

        public static IChampionDetailViewModel CreateChampionDetailViewModel(ChampionBase champion)
        {
            return new ChampionDetailViewModel(DataDragonClient, champion);
        }

        public static IChampionDetailViewModel CreateChampionDetailViewModel(string id)
        {
            return new ChampionDetailViewModel(DataDragonClient, id);
        }

        public static IItemsViewModel CreateItemsViewModel()
        {
            return new ItemsViewModel(DataDragonClient);
        }

        public static IItemDetailViewModel CreateItemDetailViewModel(Item item)
        {
            return new ItemDetailViewModel(DataDragonClient, item);
        }

        public static IItemDetailViewModel CreateItemDetailViewModel(string id)
        {
            return new ItemDetailViewModel(DataDragonClient, id);
        }
    }
}
