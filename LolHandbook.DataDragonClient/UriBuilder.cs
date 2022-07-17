using System;

namespace LolHandbook.DataDragon
{
    /// <summary>
    /// Builds Data Dragon request URIs.
    /// </summary>
    internal sealed class UriBuilder
    {
        private readonly RealmConfiguration realmConfiguration;

        internal UriBuilder(RealmConfiguration realmConfiguration)
        {
            this.realmConfiguration = realmConfiguration;
        }

        internal string Cdn => realmConfiguration.Cdn;
        internal string PatchVersion => realmConfiguration.PatchVersion;
        internal string Language => realmConfiguration.Language;

        internal Uri GetDataUri(string path)
        {
            return new Uri($"{Cdn}/{PatchVersion}/data/{Language}/{path}");
        }

        internal Uri GetImageUri(ImageId id)
        {
            return new Uri($"{Cdn}/{PatchVersion}/img/{id.Group}/{id.Full}");
        }

        internal Uri GetSkinUri(string championId, int skinNum)
        {
            return new Uri($"{Cdn}/img/champion/splash/{championId}_{skinNum}.jpg");
        }
    }
}
