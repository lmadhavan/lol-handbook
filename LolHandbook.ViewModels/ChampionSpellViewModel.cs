using DataDragon;
using System;

namespace LolHandbook.ViewModels
{
    public class ChampionSpellViewModel : ISpellViewModel
    {
        private readonly ChampionSpell championSpell;
        private readonly string resourceBurn;

        public ChampionSpellViewModel(ChampionSpell championSpell, string resourceType)
        {
            this.championSpell = championSpell;
            this.resourceBurn = championSpell.ResolveResourceBurn(resourceType);
        }

        public Uri ImageUri => championSpell.ImageUri;
        public string Name => championSpell.Name;
        public string Description => championSpell.Description;
        public string Cost => $"Cost: {resourceBurn}";
        public string Cooldown => $"Cooldown: {championSpell.CooldownBurn} seconds";
    }
}