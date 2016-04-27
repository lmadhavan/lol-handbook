using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubSummonerSpellsViewModel : ISummonerSpellsViewModel
    {
        public StubSummonerSpellsViewModel()
        {
            this.SummonerSpells = new List<ISpellViewModel>();

            for (int i = 0; i < 10; i++)
            {
                SummonerSpells.Add(new SummonerSpellViewModel(new SummonerSpell
                {
                    Name = "Spell",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                    CooldownBurn = "100",
                    SummonerLevel = 5
                }));
            }
        }

        public IList<ISpellViewModel> SummonerSpells { get; }
    }
}
