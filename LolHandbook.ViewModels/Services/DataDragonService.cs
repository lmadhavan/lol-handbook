using DataDragon;

namespace LolHandbook.ViewModels.Services
{
    public static class DataDragonService
    {
        private static CachingDataDragonClient cache;
        private static IDataDragonClient instance;

        public static IDataDragonClient Instance
        {
            get
            {
                if (cache == null)
                {
                    cache = new CachingDataDragonClient("na");
                    instance = new SanitizingDataDragonClient(new FailsafeDataDragonClient(cache));
                }

                return instance;
            }
        }

        public static void InvalidateCache()
        {
            cache?.InvalidateCache();
        }
    }
}
