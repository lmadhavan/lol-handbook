using DataDragon;
using System;

namespace LolHandbook.ViewModels
{
    public class ChampionSpellViewModel : ISpellViewModel
    {
        private readonly ChampionSpell championSpell;

        public ChampionSpellViewModel(ChampionSpell championSpell)
        {
            this.championSpell = championSpell;
        }

        public Uri ImageUri => championSpell.ImageUri;
        public string Name => championSpell.Name;
        public string Description => championSpell.Description;
        public string AdditionalInfo => null;
        public string Cooldown => $"Cooldown: {championSpell.CooldownBurn} seconds";
    }
}