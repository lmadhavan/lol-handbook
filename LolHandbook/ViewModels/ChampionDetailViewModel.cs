using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public class ChampionDetailViewModel : ViewModelBase, IChampionDetailViewModel
    {
        public ChampionDetailViewModel(DataDragonClient dataDragonClient, string id)
        {
            LoadData(dataDragonClient, id);
        }

        public ChampionBase ChampionBase => ChampionDetail;
        public ChampionDetail ChampionDetail { get; private set; }
        public IList<ISpellViewModel> Spells { get; private set; }

        private async void LoadData(DataDragonClient dataDragonClient, string id)
        {
            this.ChampionDetail = await dataDragonClient.GetChampion(id);

            this.Spells = new List<ISpellViewModel>();
            Spells.Add(new ChampionPassiveViewModel(ChampionDetail.Passive));
            foreach (ChampionSpell championSpell in ChampionDetail.Spells)
            {
                Spells.Add(new ChampionSpellViewModel(championSpell));
            }

            RaisePropertyChanged(nameof(ChampionBase));
            RaisePropertyChanged(nameof(ChampionDetail));
            RaisePropertyChanged(nameof(Spells));
        }
    }
}