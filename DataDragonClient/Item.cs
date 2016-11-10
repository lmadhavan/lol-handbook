using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataDragon
{
    public sealed class Item : ISupportTags
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Plaintext { get; set; }

        public IList<string> Tags { get; set; }

        public ISet<string> EnabledMaps { get; set; }
        [JsonProperty]
        internal IDictionary<string, bool> Maps { get; set; }

        [JsonProperty(PropertyName = "gold")]
        public ItemCost Cost { get; set; }
        [JsonProperty(PropertyName = "from")]
        public IList<string> Requires { get; set; }
        [JsonProperty(PropertyName = "into")]
        public IList<string> BuildsInto { get; set; }

        [JsonIgnore]
        public Uri ImageUri { get; set; }
        [JsonProperty]
        internal ImageId Image { get; set; }
    }
}
