using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubSummonerSpellsViewModel
    {
        public StubSummonerSpellsViewModel()
        {
            this.SummonerSpells = new List<SummonerSpell>();

            for (int i = 0; i < 10; i++)
            {
                SummonerSpells.Add(new SummonerSpell
                {
                    Name = "Spell",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                    CooldownBurn = "100"
                });
            }
        }

        public IList<SummonerSpell> SummonerSpells { get; }
    }
}
