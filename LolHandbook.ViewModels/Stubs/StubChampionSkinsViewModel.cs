using LolHandbook.DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionSkinsViewModel : ChampionSkinsViewModel
    {
        public StubChampionSkinsViewModel()
        {
            this.Skins = new List<ChampionSkin>
            {
                new ChampionSkin { Name = "Skin 1" },
                new ChampionSkin { Name = "Skin 2" },
                new ChampionSkin { Name = "Skin 3" }
            };
        }
    }
}
