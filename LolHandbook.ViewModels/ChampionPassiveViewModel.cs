using DataDragon;
using System;

namespace LolHandbook.ViewModels
{
    public class ChampionPassiveViewModel : ISpellViewModel
    {
        private readonly ChampionPassive championPassive;

        public ChampionPassiveViewModel(ChampionPassive championPassive)
        {
            this.championPassive = championPassive;
        }

        public Uri ImageUri => championPassive.ImageUri;
        public string Name => championPassive.Name;
        public string Description => championPassive.Description;
        public string Cost => "Passive";
        public string Cooldown => null;
    }
}