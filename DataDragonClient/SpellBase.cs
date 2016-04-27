using Newtonsoft.Json;
using System;

namespace DataDragon
{
    public abstract class SpellBase
    {
        internal SpellBase()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public Uri ImageUri { get; set; }
        [JsonProperty]
        internal ImageId Image { get; set; }
    }
}
