using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataDragon
{
    public class Entity : ISupportTags
    {
        public string Name { get; set; }
        public IList<string> Tags { get; set; }

        [JsonIgnore]
        public Uri ImageUri { get; set; }
        [JsonProperty]
        internal ImageId Image { get; set; }
    }
}
