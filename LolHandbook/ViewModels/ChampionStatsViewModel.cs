using DataDragon;

namespace LolHandbook.ViewModels
{
    public class ChampionStatsViewModel
    {
        private readonly ChampionStats stats;

        public ChampionStatsViewModel(ChampionStats stats)
        {
            this.stats = stats;
        }

        public string Health => $"{stats.HitPoints} (+{stats.HitPointsPerLevel} per level)";
        public string HealthRegen => $"{stats.HitPointRegeneration} (+{stats.HitPointRegenerationPerLevel} per level)";
        public string Armor => $"{stats.Armor} (+{stats.ArmorPerLevel} per level)";

        public string Mana => $"{stats.ManaPoints} (+{stats.ManaPointsPerLevel} per level)";
        public string ManaRegen => $"{stats.ManaPointRegeneration} (+{stats.ManaPointRegenerationPerLevel} per level)";
        public string MagicResist => $"{stats.SpellBlock} (+{stats.SpellBlockPerLevel} per level)";

        public string MovementSpeed => $"{stats.MoveSpeed}";
        public string AttackSpeed => $"{stats.AttackSpeed:F3} (+{stats.AttackSpeedPerLevel}% per level)";
        public string AttackDamage => $"{stats.AttackDamage} (+{stats.AttackDamagePerLevel} per level)";
        public string AttackRange => $"{stats.AttackRange}";
    }
}
