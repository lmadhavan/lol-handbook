using System;
using System.Threading;
using System.Threading.Tasks;

namespace LolHandbook.DataDragon
{
    /// <summary>
    /// Holds a reference to a lazy-initialized <see cref="UriBuilder"/> instance.
    /// </summary>
    internal sealed class UriBuilderReference : IDisposable
    {
        private readonly RealmConfiguration realmConfiguration;

        private readonly SemaphoreSlim fetchLock;
        private UriBuilder uriBuilder;

        internal UriBuilderReference(RealmConfiguration realmConfiguration)
        {
            this.realmConfiguration = realmConfiguration;
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
                    Uri realmFile = new Uri($"http://ddragon.leagueoflegends.com/realms/{realmConfiguration.Realm}.json");
                    RealmConfiguration defaultRealmConfiguration = await httpClient.GetAsync<RealmConfiguration>(realmFile);

                    RealmConfiguration mergedRealmConfiguration = MergeRealmConfiguration(realmConfiguration, defaultRealmConfiguration);
                    instance = new UriBuilder(mergedRealmConfiguration);
                    this.uriBuilder = instance;
                }

                return instance;
            }
            finally
            {
                fetchLock.Release();
            }
        }

        private RealmConfiguration MergeRealmConfiguration(RealmConfiguration overrideRealmConfiguration, RealmConfiguration defaultRealmConfiguration)
        {
            RealmConfiguration result = new RealmConfiguration(overrideRealmConfiguration.Realm);
            result.Cdn = overrideRealmConfiguration.Cdn ?? defaultRealmConfiguration.Cdn;
            result.PatchVersion = overrideRealmConfiguration.PatchVersion ?? defaultRealmConfiguration.PatchVersion;
            result.Language = overrideRealmConfiguration.Language ?? defaultRealmConfiguration.Language;
            return result;
        }

        internal void Reset()
        {
            this.uriBuilder = null;
        }
    }
}
