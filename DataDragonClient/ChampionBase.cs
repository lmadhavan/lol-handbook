using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataDragon
{
    public abstract class ChampionBase
    {
        internal ChampionBase()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }

        public IList<string> Tags { get; set; }
        public ChampionStats Stats { get; set; }

        [JsonProperty(PropertyName = "info")]
        public ChampionRating Rating { get; set; }

        [JsonIgnore]
        public Uri ImageUri { get; set; }
        [JsonProperty]
        internal ImageId Image { get; set; }
    }
}
