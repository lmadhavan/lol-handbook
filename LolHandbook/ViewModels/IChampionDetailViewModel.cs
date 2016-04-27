using DataDragon;

namespace LolHandbook.ViewModels
{
    public interface IChampionDetailViewModel
    {
        ChampionBase ChampionBase { get; }
        ChampionDetail ChampionDetail { get; }
    }
}
