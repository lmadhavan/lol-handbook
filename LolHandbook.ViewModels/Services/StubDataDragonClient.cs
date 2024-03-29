﻿using LolHandbook.DataDragon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class StubDataDragonClient : IDataDragonClient
    {
        private readonly IDictionary<string, ChampionSummary> champions;
        private readonly ChampionDetail champion;
        private readonly IDictionary<string, Item> items;

        public StubDataDragonClient()
        {
            this.champions = new Dictionary<string, ChampionSummary>();
            for (int i = 0; i < 25; i++)
            {
                champions[i.ToString()] = new ChampionSummary { Name = "Champion " + i };
            }

            this.champion = new ChampionDetail
            {
                Id = "ID",
                Name = "Champion",
                Title = "with Some Title",
                Tags = new List<string> { "Fighter", "Tank" },
                Blurb = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                Lore = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                AllyTips = new List<string> { "Tip 1", "Tip 2" },
                EnemyTips = new List<string> { "Tip 3", "Tip 4" },
                Skins = new List<ChampionSkin> { new ChampionSkin() },
                Spells = new List<ChampionSpell>(),
                Stats = new ChampionStats()
            };

            champion.Passive = new ChampionPassive
            {
                Name = "Passive",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis."
            };

            champion.Spells.Add(new ChampionSpell
            {
                Name = "Spell 1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                CooldownBurn = "5/4/3/2/1",
                Resource = "{{ cost }} Mana",
                CostBurn = "50"
            });

            champion.Spells.Add(new ChampionSpell
            {
                Name = "Spell 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam in quam purus. Donec at lacus felis.",
                CooldownBurn = "0.5",
                Resource = "{{ e1 }}% of current Health",
                EffectBurn = new List<string>(new string[] { null, "20" })
            });

            this.items = new Dictionary<string, Item>();
            items["0"] = new Item
            {
                Name = "Item 0",
                Cost = new ItemCost { Total = 1000 },
                Description = "+100 Attack Damage\n+100 Health",
                Plaintext = "An excellent item",
                Requires = new List<string> { "1" },
                BuildsInto = new List<string> { "2" }
            };
            items["1"] = new Item { Name = "Item 1" };
            items["2"] = new Item { Name = "Item 2" };
        }

        public void Dispose()
        {
        }

        public async Task<string> GetPatchVersionAsync()
        {
            return await Task.FromResult("1.2.3");
        }

        public async Task<IDictionary<string, string>> GetLocalizedStringsAsync()
        {
            return await Task.FromResult(new Dictionary<string, string>());
        }

        public async Task<IDictionary<string, ChampionSummary>> GetChampionSummariesAsync()
        {
            return await Task.FromResult(champions);
        }

        public async Task<ChampionDetail> GetChampionDetailAsync(string id)
        {
            return await Task.FromResult(champion);
        }

        public Task<IDictionary<string, SummonerSpell>> GetSummonerSpellsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDictionary<string, Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
    }
}
