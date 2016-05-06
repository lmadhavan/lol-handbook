using Newtonsoft.Json;

namespace DataDragon
{
    internal sealed class RealmInfo
    {
        [JsonProperty(PropertyName = "v")]
        internal string PatchVersion { get; set; }

        [JsonProperty(PropertyName = "l")]
        internal string DefaultLanguage { get; set; }

        [JsonProperty(PropertyName = "cdn")]
        internal string Cdn { get; set; }
    }
}
