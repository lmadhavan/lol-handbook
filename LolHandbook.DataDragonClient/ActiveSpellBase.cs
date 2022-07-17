using Newtonsoft.Json;
using System.Collections.Generic;

namespace LolHandbook.DataDragon
{
    public abstract class ActiveSpellBase : SpellBase
    {
        internal ActiveSpellBase()
        {
        }

        [JsonProperty(PropertyName = "tooltip")]
        public string ToolTip { get; set; }
        [JsonProperty(PropertyName = "leveltip")]
        public LevelTip LevelTip { get; set; }

        [JsonProperty(PropertyName = "maxrank")]
        public int MaxRank { get; set; }

        public IList<double> Cooldown { get; set; }
        public string CooldownBurn { get; set; }

        public IList<double> Cost { get; set; }
        public string CostBurn { get; set; }
        public string CostType { get; set; }
        public string Resource { get; set; }

        public IList<IList<double>> Effect { get; set; }
        public IList<string> EffectBurn { get; set; }

        public IList<double> Range { get; set; }
        public string RangeBurn { get; set; }
    }
}
