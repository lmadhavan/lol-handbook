using Newtonsoft.Json;

namespace DataDragon
{
    public sealed class ChampionStats
    {
        [JsonProperty(PropertyName = "hp")]
        public double HitPoints { get; set; }

        [JsonProperty(PropertyName = "hpperlevel")]
        public double HitPointsPerLevel { get; set; }

        [JsonProperty(PropertyName = "mp")]
        public double ManaPoints { get; set; }

        [JsonProperty(PropertyName = "mpperlevel")]
        public double ManaPointsPerLevel { get; set; }

        [JsonProperty(PropertyName = "movespeed")]
        public double MoveSpeed { get; set; }

        [JsonProperty(PropertyName = "armor")]
        public double Armor { get; set; }

        [JsonProperty(PropertyName = "armorperlevel")]
        public double ArmorPerLevel { get; set; }

        [JsonProperty(PropertyName = "spellblock")]
        public double SpellBlock { get; set; }

        [JsonProperty(PropertyName = "spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }

        [JsonProperty(PropertyName = "attackrange")]
        public double AttackRange { get; set; }

        [JsonProperty(PropertyName = "hpregen")]
        public double HitPointRegeneration { get; set; }

        [JsonProperty(PropertyName = "hpregenperlevel")]
        public double HitPointRegenerationPerLevel { get; set; }

        [JsonProperty(PropertyName = "mpregen")]
        public double ManaPointRegeneration { get; set; }

        [JsonProperty(PropertyName = "mpregenperlevel")]
        public double ManaPointRegenerationPerLevel { get; set; }

        [JsonProperty(PropertyName = "crit")]
        public double CriticalStrike { get; set; }

        [JsonProperty(PropertyName = "critperlevel")]
        public double CriticalStrikePerLevel { get; set; }

        [JsonProperty(PropertyName = "attackdamage")]
        public double AttackDamage { get; set; }

        [JsonProperty(PropertyName = "attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        [JsonProperty(PropertyName = "attackspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        [JsonProperty(PropertyName = "attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }

        [JsonIgnore]
        public double AttackSpeed => 0.625 / (1 + AttackSpeedOffset);
    }
}
