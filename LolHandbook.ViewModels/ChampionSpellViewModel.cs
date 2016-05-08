using DataDragon;
using System;

namespace LolHandbook.ViewModels
{
    public class ChampionSpellViewModel : ISpellViewModel
    {
        private readonly ChampionSpell championSpell;
        private readonly string resourceBurn;

        public ChampionSpellViewModel(ChampionSpell championSpell)
        {
            this.championSpell = championSpell;
            this.resourceBurn = championSpell.ResolveResourceBurn();
        }

        public Uri ImageUri => championSpell.ImageUri;
        public string Name => championSpell.Name;
        public string Description => HtmlSanitizer.Sanitize(championSpell.Description);
        public string AdditionalInfo => $"Cost: {resourceBurn}";
        public string Cooldown => $"Cooldown: {championSpell.CooldownBurn} seconds";
    }
}