using System.Collections.Generic;
using Windows.UI.Xaml;

namespace LolHandbook.ViewModels
{
    public interface IChampionDetailViewModel
    {
        string Name { get; }
        string Title { get; }
        string Role { get; }
        string Blurb { get; }

        Visibility MoreButtonVisible { get; }
        string Lore { get; }

        IList<ISpellViewModel> Spells { get; }
        ChampionStatsViewModel Stats { get; }

        string AllyTips { get; }
        string EnemyTips { get; }
    }
}
