using DataDragon;

namespace LolHandbook.ViewModels.Services
{
    public static class DataDragonService
    {
        private static FailsafeDataDragonClient instance;

        public static IDataDragonClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FailsafeDataDragonClient();
                }

                return instance;
            }
        }

        public static void InvalidateCache()
        {
            if (instance != null)
            {
                instance.InvalidateCache();
            }
        }
    }
}
