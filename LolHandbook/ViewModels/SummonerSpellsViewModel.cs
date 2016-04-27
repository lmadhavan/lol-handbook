using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class SummonerSpellsViewModel : ViewModelBase, ISummonerSpellsViewModel
    {
        public SummonerSpellsViewModel(DataDragonClient dataDragonClient)
        {
            LoadData(dataDragonClient);
        }

        public IList<ISpellViewModel> SummonerSpells
        {
            get;
            private set;
        }

        private async void LoadData(DataDragonClient dataDragonClient)
        {
            Debug.Write("Fetching summoner spells... ");
            IList<SummonerSpell> summonerSpells = await dataDragonClient.GetSummonerSpellsAsync();
            Debug.WriteLine("Done.");

            this.SummonerSpells = summonerSpells.Select(ss => new SummonerSpellViewModel(ss)).ToList<ISpellViewModel>();
            RaisePropertyChanged(nameof(SummonerSpells));
        }
    }
}
