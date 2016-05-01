using System;

namespace DataDragon
{
    internal sealed class UriBuilder
    {
        private const string Cdn = "http://ddragon.leagueoflegends.com/cdn";
        private const string Version = "6.8.1";
        private const string Language = "en_US";

        internal Uri GetDataUri(string path)
        {
            return new Uri($"{Cdn}/{Version}/data/{Language}/{path}");
        }

        internal Uri GetImageUri(ImageId id)
        {
            return new Uri($"{Cdn}/{Version}/img/{id.Group}/{id.Full}");
        }

        internal Uri GetSkinUri(string championId, int skinNum)
        {
            return new Uri($"{Cdn}/img/champion/splash/{championId}_{skinNum}.jpg");
        }
    }
}
