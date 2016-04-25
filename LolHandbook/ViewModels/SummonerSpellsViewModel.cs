using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;

namespace LolHandbook.ViewModels
{
    public class SummonerSpellsViewModel : ViewModelBase, ISummonerSpellsViewModel
    {
        public SummonerSpellsViewModel(DataDragonClient dataDragonClient)
            : base(dataDragonClient)
        {
        }

        public IList<SummonerSpell> SummonerSpells
        {
            get;
            private set;
        }

        protected override async void LoadData(DataDragonClient dataDragonClient)
        {
            Debug.Write("Fetching summoner spells... ");
            this.SummonerSpells = await dataDragonClient.GetSummonerSpellsAsync();
            Debug.WriteLine("Done.");

            RaisePropertyChanged(nameof(SummonerSpells));
        }
    }
}
