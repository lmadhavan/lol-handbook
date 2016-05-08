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
                Resource = "{{ cost }} Mana + {{ e1 }} Mana per second + {{ e2 }} Health",
                CostBurn = "10",
                EffectBurn = new List<string> { null, "20", "30" }
            };

            Assert.That(spell.ResolveResourceBurn(), Is.EqualTo("10 Mana + 20 Mana per second + 30 Health"));
        }
    }
}
