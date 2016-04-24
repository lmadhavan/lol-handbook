using DataDragon;
using System.Collections.Generic;
using System.ComponentModel;

namespace LolHandbook.ViewModels
{
    public class SummonerSpellsViewModel : INotifyPropertyChanged
    {
        public IList<SummonerSpell> SummonerSpells
        {
            get;
            private set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Load()
        {
            if (SummonerSpells != null)
            {
                return;
            }

            using (DataDragonClient client = new DataDragonClient())
            {
                this.SummonerSpells = await client.GetSummonerSpellsAsync();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SummonerSpells)));
            }
        }
    }
}
