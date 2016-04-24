using Newtonsoft.Json;
using System;

namespace DataDragon
{
    public sealed class SummonerSpell
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CooldownBurn { get; set; }
        public int SummonerLevel { get; set; }
        public string RangeBurn { get; set; }
        public Uri ImageUri { get; set; }

        [JsonProperty]
        internal ImageId Image { get; set; }
    }
}
