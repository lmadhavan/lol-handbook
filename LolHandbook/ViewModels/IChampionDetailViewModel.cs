using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IChampionDetailViewModel : IAsyncViewModel
    {
        Uri IconUri { get; }
        Uri SkinUri { get; }

        string Name { get; }
        string Title { get; }
        string Role { get; }
        string Blurb { get; }
        string Lore { get; }

        IList<ISpellViewModel> Spells { get; }
        ChampionStatsViewModel Stats { get; }

        string AllyTips { get; }
        string EnemyTips { get; }
    }
}
