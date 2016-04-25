using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface ISummonerSpellsViewModel
    {
        IList<SummonerSpell> SummonerSpells { get; }
    }
}
