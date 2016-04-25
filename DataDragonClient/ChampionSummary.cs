using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataDragon
{
    public sealed class ChampionSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public IList<string> Tags { get; set; }
        public Uri ImageUri { get; set; }

        [JsonProperty]
        internal ImageId Image { get; set; }
    }
}
