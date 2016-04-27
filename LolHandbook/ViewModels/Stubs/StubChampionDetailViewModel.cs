using DataDragon;
using System.Collections.Generic;
using System.Linq;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionDetailViewModel : IChampionDetailViewModel
    {
        public StubChampionDetailViewModel()
        {
            this.ChampionDetail = new ChampionDetail
            {
                Name = "Champion",
                Title = "the Titular Champion",
                Blurb = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                Lore = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Tags = new List<string>(new string[] { "Fighter", "Tank" }),
                Stats = new ChampionStats(),

                Rating = new ChampionRating
                {
                    Attack = 6,
                    Defense = 5,
                    Magic = 4,
                    Difficulty = 8
                },

                AllyTips = new List<string>(new string[] { "Stay close to him." }),
                EnemyTips = new List<string>(new string[] { "Stay away from him." }),

                Passive = new ChampionPassive
                {
                    Name = "Passive",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis."
                },

                Spells = new List<ChampionSpell>(new ChampionSpell[] {
                    new ChampionSpell
                    {
                        Name = "Spell 1",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                        CooldownBurn = "5/4/3/2/1",
                        Resource = "{{ cost }} Mana",
                        CostBurn = "50"
                    },

                    new ChampionSpell
                    {
                        Name = "Spell 2",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                        CooldownBurn = "0.5",
                        Resource = "{{ e1 }}% of current Health",
                        EffectBurn = new List<string>(new string[] { null, "20" })
                    }
                })
            };
        }

        public ChampionDetail ChampionDetail { get; set; }
        public ChampionBase ChampionBase => ChampionDetail;
    }
}
