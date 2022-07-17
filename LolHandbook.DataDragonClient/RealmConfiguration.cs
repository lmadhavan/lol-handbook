using Newtonsoft.Json;

namespace LolHandbook.DataDragon
{
    /// <summary>
    /// Specifies configuration parameters for a Data Dragon realm.
    /// </summary>
    public sealed class RealmConfiguration
    {
        [JsonConstructor]
        internal RealmConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RealmConfiguration"/> with the specified realm code.
        /// </summary>
        /// <param name="realm">A Data Dragon realm code, for example, "na"</param>
        public RealmConfiguration(string realm)
        {
            this.Realm = realm;
        }

        /// <summary>
        /// Gets the realm code associated with the current <see cref="RealmConfiguration"/> instance.
        /// </summary>
        public string Realm { get; }

        /// <summary>
        /// Gets or sets the base URL for the Data Dragon CDN.
        /// </summary>
        [JsonProperty(PropertyName = "cdn")]
        public string Cdn { get; set; }

        /// <summary>
        /// Gets or sets the patch version used by the client.
        /// </summary>
        [JsonProperty(PropertyName = "v")]
        public string PatchVersion { get; set; }

        /// <summary>
        /// Gets or sets the language code used by the client.
        /// </summary>
        [JsonProperty(PropertyName = "l")]
        public string Language { get; set; }
    }
}
