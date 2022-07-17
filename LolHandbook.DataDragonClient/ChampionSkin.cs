using Newtonsoft.Json;
using System;

namespace LolHandbook.DataDragon
{
    public sealed class ChampionSkin
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public Uri ImageUri { get; set; }
        [JsonProperty]
        internal int Num { get; set; }
    }
}
