using DataDragon;

namespace LolHandbook.ViewModels
{
    public class ChampionDetailViewModel : ViewModelBase, IChampionDetailViewModel
    {
        public ChampionDetailViewModel(DataDragonClient dataDragonClient, string id)
        {
            LoadData(dataDragonClient, id);
        }

        public ChampionBase ChampionBase => ChampionDetail;
        public ChampionDetail ChampionDetail { get; set; }

        private async void LoadData(DataDragonClient dataDragonClient, string id)
        {
            this.ChampionDetail = await dataDragonClient.GetChampion(id);
            RaisePropertyChanged(nameof(ChampionBase));
            RaisePropertyChanged(nameof(ChampionDetail));
        }
    }
}