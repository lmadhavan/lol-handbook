﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace LolHandbook.DataDragon
{
    public sealed class ChampionDetail : ChampionBase
    {
        public string Lore { get; set; }
        public IList<ChampionSkin> Skins { get; set; }

        [JsonProperty(PropertyName = "allytips")]
        public IList<string> AllyTips { get; set; }
        [JsonProperty(PropertyName = "enemytips")]
        public IList<string> EnemyTips { get; set; }

        [JsonProperty(PropertyName = "partype")]
        public string ResourceType { get; set; }

        public IList<ChampionSpell> Spells { get; set; }
        public ChampionPassive Passive { get; set; }
    }
}
