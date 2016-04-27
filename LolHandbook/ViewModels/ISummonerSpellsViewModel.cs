using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface ISummonerSpellsViewModel
    {
        IList<ISpellViewModel> SummonerSpells { get; }
    }
}
