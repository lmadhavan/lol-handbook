using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataDragon
{
    /// <summary>
    /// Holds a reference to a lazy-initialized <see cref="UriBuilder"/> instance.
    /// </summary>
    internal sealed class UriBuilderReference : IDisposable
    {
        private readonly string realm;
        private readonly string language;

        private readonly SemaphoreSlim fetchLock;
        private UriBuilder uriBuilder;

        internal UriBuilderReference(string realm, string language)
        {
            this.realm = realm;
            this.language = language;
            this.fetchLock = new SemaphoreSlim(1, 1);
        }

        public void Dispose()
        {
            fetchLock.Dispose();
        }

        internal async Task<UriBuilder> GetUriBuilderAsync(JsonHttpClient httpClient)
        {
            UriBuilder instance = this.uriBuilder;

            if (instance != null)
            {
                return instance;
            }

            await fetchLock.WaitAsync();
            try
            {
                instance = this.uriBuilder;

                if (instance == null)
                {
                    Uri realmFile = new Uri($"http://ddragon.leagueoflegends.com/realms/{realm}.json");
                    RealmInfo realmInfo = await httpClient.GetAsync<RealmInfo>(realmFile);

                    instance = new UriBuilder(realmInfo, language);
                    this.uriBuilder = instance;
                }

                return instance;
            }
            finally
            {
                fetchLock.Release();
            }
        }

        internal void Reset()
        {
            this.uriBuilder = null;
        }
    }
}
