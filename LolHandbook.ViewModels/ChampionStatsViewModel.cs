using LolHandbook.DataDragon;

namespace LolHandbook.ViewModels
{
    public class ChampionStatsViewModel
    {
        private readonly ChampionStats stats;
        private readonly string resourceType;

        public ChampionStatsViewModel(ChampionStats stats, string resourceType)
        {
            this.stats = stats;
            this.resourceType = resourceType;
        }

        public string Health => $"{stats.HitPoints} (+{stats.HitPointsPerLevel} per level)";
        public string HealthRegen => $"{stats.HitPointRegeneration} (+{stats.HitPointRegenerationPerLevel} per level)";

        public bool HasResourceRegen => stats.ManaPointRegeneration > 0;
        public string ResourceLabel => resourceType + ":";
        public string Resource => HasResourceRegen ? $"{stats.ManaPoints} (+{stats.ManaPointsPerLevel} per level)" : "N/A";
        public string ResourceRegenLabel => resourceType + " Regen:";
        public string ResourceRegen => HasResourceRegen ? $"{stats.ManaPointRegeneration} (+{stats.ManaPointRegenerationPerLevel} per level)" : "N/A";

        public string Armor => $"{stats.Armor} (+{stats.ArmorPerLevel} per level)";
        public string MagicResist => $"{stats.SpellBlock} (+{stats.SpellBlockPerLevel} per level)";

        public string MovementSpeed => $"{stats.MoveSpeed}";
        public string AttackSpeed => $"{stats.AttackSpeed:F3} (+{stats.AttackSpeedPerLevel}% per level)";
        public string AttackDamage => $"{stats.AttackDamage} (+{stats.AttackDamagePerLevel} per level)";
        public string AttackRange => $"{stats.AttackRange}";
    }
}
