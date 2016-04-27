using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IChampionDetailViewModel
    {
        ChampionBase ChampionBase { get; }
        ChampionDetail ChampionDetail { get; }
        IList<ISpellViewModel> Spells { get; }
    }
}
