using Newtonsoft.Json;

namespace LolHandbook.DataDragon
{
    internal sealed class ImageId
    {
        [JsonProperty]
        internal string Full { get; set; }

        [JsonProperty]
        internal string Group { get; set; }
    }
}
