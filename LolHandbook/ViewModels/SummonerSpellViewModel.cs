using DataDragon;
using System;

namespace LolHandbook.ViewModels
{
    public class SummonerSpellViewModel : ISpellViewModel
    {
        private readonly SummonerSpell summonerSpell;

        public SummonerSpellViewModel(SummonerSpell summonerSpell)
        {
            this.summonerSpell = summonerSpell;
        }

        public Uri ImageUri => summonerSpell.ImageUri;
        public string Name => summonerSpell.Name;
        public string Description => summonerSpell.Description;
        public string AdditionalInfo => $"Requires summoner level {summonerSpell.SummonerLevel}";
        public string Cooldown => $"Cooldown: {summonerSpell.CooldownBurn} seconds";
    }
}