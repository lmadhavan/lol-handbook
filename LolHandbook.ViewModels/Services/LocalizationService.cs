using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class LocalizationService : ILocalizationService
    {
        private static LocalizationService instance;

        private readonly DataDragonService dataDragonService;
        private LanguageDictionary languageDictionary;

        private LocalizationService()
        {
            this.dataDragonService = DataDragonService.Instance;
        }

        public static LocalizationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalizationService();
                }

                return instance;
            }
        }

        public async Task LoadData(bool forceReload)
        {
            this.languageDictionary = new LanguageDictionary(await dataDragonService.GetLocalizedStringsAsync(forceReload));
        }

        public string Lookup(string key)
        {
            return languageDictionary?.Lookup(key) ?? key;
        }
    }
}
