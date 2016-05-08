using DataDragon;
using System.Text.RegularExpressions;

namespace LolHandbook.ViewModels
{
    internal static class ChampionSpellExtensions
    {
        private static readonly Regex ResourcePattern = new Regex(@"\{\{ (\w+) \}\}");

        internal static string ResolveResourceBurn(this ChampionSpell championSpell)
        {
            string resource = championSpell.Resource;

            Match match = ResourcePattern.Match(resource);
            while (match.Success)
            {
                string expression = match.Groups[0].Value;
                string variable = match.Groups[1].Value;
                string variableValue = championSpell.ResolveVariable(variable);

                resource = resource.Replace(expression, variableValue);
                match = match.NextMatch();
            }

            return resource;
        }

        private static string ResolveVariable(this ChampionSpell championSpell, string variable)
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
