using System.Collections.Generic;

namespace LolHandbook.ViewModels.Services
{
    internal sealed class LanguageDictionary
    {
        private IDictionary<string, string> localizedStrings;

        internal LanguageDictionary(IDictionary<string, string> localizedStrings)
        {
            this.localizedStrings = localizedStrings;
        }

        public string Lookup(string key)
        {
            if (key.EndsWith(":"))
            {
                key = key.Substring(0, key.Length - 1);
                return Lookup(key) + ":";
            }

            string value;
            if (localizedStrings.TryGetValue(key, out value))
            {
                return value;
            }

            return key;
        }
    }
}
