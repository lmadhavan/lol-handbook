using DataDragon;

namespace LolHandbook.ViewModels
{
    public sealed class ViewModelFactory
    {
        private static DataDragonClient dataDragonClient;

        private static DataDragonClient DataDragonClient
        {
            get
            {
                if (dataDragonClient == null)
                {
                    dataDragonClient = new DataDragonClient();
                }

                return dataDragonClient;
            }
        }

        public static IChampionsViewModel CreateChampionsViewModel()
        {
            return new ChampionsViewModel(DataDragonClient);
        }

        public static ISummonerSpellsViewModel CreateSummonerSpellsViewModel()
        {
            return new SummonerSpellsViewModel(DataDragonClient);
        }
    }
}
