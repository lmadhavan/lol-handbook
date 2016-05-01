using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionDetailViewModel : IChampionDetailViewModel
    {
        public StubChampionDetailViewModel()
        {
            this.Spells = new List<ISpellViewModel>();
            Spells.Add(new ChampionPassiveViewModel(new ChampionPassive
            {
                Name = "Passive",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis."
            }));
            Spells.Add(new ChampionSpellViewModel(new ChampionSpell
            {
                Name = "Spell 1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                CooldownBurn = "5/4/3/2/1",
                Resource = "{{ cost }} Mana",
                CostBurn = "50"
            }));
            Spells.Add(new ChampionSpellViewModel(new ChampionSpell
            {
                Name = "Spell 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                CooldownBurn = "0.5",
                Resource = "{{ e1 }}% of current Health",
                EffectBurn = new List<string>(new string[] { null, "20" })
            }));

            this.Stats = new ChampionStatsViewModel(new ChampionStats());
        }

        public string Name => "Champion";
        public string Title => "with Some Title";
        public string Role => "Role: Fighter, Tank";
        public string Blurb => "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.";
        public string Lore => "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public IList<ISpellViewModel> Spells { get; private set; }
        public ChampionStatsViewModel Stats { get; private set; }

        public string AllyTips => "- Tip 1\n- Tip 2";
        public string EnemyTips => "- Tip 3\n- Tip 4";
    }
}
