using DataDragon;
using NUnit.Framework;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    [TestFixture]
    public class ChampionSpellExtensionsTest
    {
        [Test]
        public void ResolvesResourceBurn()
        {
            ChampionSpell spell = new ChampionSpell
            {
                Resource = "{{ cost }} {{ abilityresourcename }} + {{ e1 }} {{ abilityresourcename }} per second + {{ e2 }} Health",
                CostBurn = "10",
                EffectBurn = new List<string> { null, "20", "30" }
            };

            Assert.That(spell.ResolveResourceBurn("Mana"), Is.EqualTo("10 Mana + 20 Mana per second + 30 Health"));
        }

        [Test]
        public void RemovesUnknownPlaceholders()
        {
            ChampionSpell spell = new ChampionSpell
            {
                Resource = "{{ basemanacost }} Mana + {{ percentmanacost*100 }}% Max Mana"
            };

            Assert.That(spell.ResolveResourceBurn(""), Is.EqualTo("⯑ Mana + ⯑% Max Mana"));
        }
    }
}
