using System;

namespace DataDragon
{
    /// <summary>
    /// Builds Data Dragon request URIs.
    /// </summary>
    internal sealed class UriBuilder
    {
        private readonly RealmInfo realmInfo;
        private readonly string language;

        internal UriBuilder(RealmInfo realmInfo, string language)
        {
            this.realmInfo = realmInfo;
            this.language = language;
        }

        internal string Cdn => realmInfo.Cdn;
        internal string PatchVersion => realmInfo.PatchVersion;
        internal string Language => language ?? realmInfo.DefaultLanguage;

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
