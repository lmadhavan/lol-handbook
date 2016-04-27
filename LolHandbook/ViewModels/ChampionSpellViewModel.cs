using DataDragon;
using System;
using System.Text.RegularExpressions;

namespace LolHandbook.ViewModels
{
    public class ChampionSpellViewModel : ISpellViewModel
    {
        private static readonly Regex ResourcePattern = new Regex(@"\{\{ (\w+) \}\}");

        private readonly ChampionSpell championSpell;
        private readonly string resourceBurn;

        public ChampionSpellViewModel(ChampionSpell championSpell)
        {
            this.championSpell = championSpell;
            this.resourceBurn = ResolveResourceBurn();
        }

        public Uri ImageUri => championSpell.ImageUri;
        public string Name => championSpell.Name;
        public string Description => HtmlSanitizer.Sanitize(championSpell.Description);
        public string AdditionalInfo => $"Cost: {resourceBurn}";
        public string Cooldown => $"Cooldown: {championSpell.CooldownBurn} seconds";

        private string ResolveResourceBurn()
        {
            string resource = championSpell.Resource;

            Match match = ResourcePattern.Match(resource);
            while (match.Success)
            {
                string expression = match.Groups[0].Value;
                string variable = match.Groups[1].Value;
                string variableValue = ResolveVariable(variable);

                resource = resource.Replace(expression, variableValue);
                match = match.NextMatch();
            }

            return resource;
        }

        private string ResolveVariable(string variable)
        {
            if (variable == "cost")
            {
                return championSpell.CostBurn;
            }

            if (variable.StartsWith("e"))
            {
                int i;

                if (int.TryParse(variable.Substring(1), out i))
                {
                    if (i >= 0 && i < championSpell.EffectBurn.Count)
                    {
                        return championSpell.EffectBurn[i];
                    }
                }
            }

            return variable;
        }
    }
}