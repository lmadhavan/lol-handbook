using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataDragon
{
    public sealed class Item : Entity
    {
        public string Group { get; set; }
        public string Description { get; set; }
        public string Plaintext { get; set; }

        public ISet<string> EnabledMaps { get; set; }
        [JsonProperty]
        internal IDictionary<string, bool> Maps { get; set; }

        [JsonProperty(PropertyName = "gold")]
        public ItemCost Cost { get; set; }
        [JsonProperty(PropertyName = "from")]
        public IList<string> Requires { get; set; }
        [JsonProperty(PropertyName = "into")]
        public IList<string> BuildsInto { get; set; }
    }
}
