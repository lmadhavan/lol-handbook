using Newtonsoft.Json;

namespace DataDragon
{
    public abstract class ChampionBase : Entity
    {
        internal ChampionBase()
        {
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }

        public ChampionStats Stats { get; set; }

        [JsonProperty(PropertyName = "info")]
        public ChampionRating Rating { get; set; }
    }
}
