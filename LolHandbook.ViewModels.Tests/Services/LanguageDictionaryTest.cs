using NUnit.Framework;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Services
{
    [TestFixture]
    public class LanguageDictionaryTest
    {
        private IDictionary<string, string> localizedStrings;
        private LanguageDictionary languageDictionary;

        [SetUp]
        public void SetUp()
        {
            this.localizedStrings = new Dictionary<string, string>();
            localizedStrings["Foo"] = "Bar";

            this.languageDictionary = new LanguageDictionary(localizedStrings);
        }

        [Test]
        public void LooksUpKey()
        {
            Assert.That(languageDictionary.Lookup("Foo"), Is.EqualTo("Bar"));
        }

        [Test]
        public void LooksUpKeyWithColonSuffix()
        {
            Assert.That(languageDictionary.Lookup("Foo:"), Is.EqualTo("Bar:"));
        }

        [Test]
        public void DefaultsToKey()
        {
            Assert.That(languageDictionary.Lookup("Baz"), Is.EqualTo("Baz"));
        }
    }
}
