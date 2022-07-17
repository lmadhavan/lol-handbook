using LolHandbook.DataDragon;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels.Services
{
    public sealed class LocalizationService : ILocalizationService
    {
        private static LocalizationService instance;

        private readonly IDataDragonClient dataDragonClient;
        private LanguageDictionary languageDictionary;

        private LocalizationService()
        {
            this.dataDragonClient = DataDragonService.Instance;
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

        public async Task LoadData()
        {
            this.languageDictionary = new LanguageDictionary(await dataDragonClient.GetLocalizedStringsAsync());
        }

        public string Lookup(string key)
        {
            return languageDictionary?.Lookup(key) ?? key;
        }
    }
}
