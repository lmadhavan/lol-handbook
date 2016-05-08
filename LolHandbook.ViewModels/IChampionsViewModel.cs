using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IChampionsViewModel : IFilterableViewModel
    {
        IList<ChampionSummary> Champions { get; }
    }
}
