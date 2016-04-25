using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IChampionsViewModel
    {
        IList<ChampionSummary> Champions { get; }
        IList<string> Tags { get; }
        string TagFilter { get; set; }
    }
}
