using NUnit.Framework;

namespace LolHandbook.ViewModels
{
    [TestFixture]
    public class MainPageViewModelTest
    {
        [Test]
        public void GeneratesPatchNotesUrl()
        {
            Assert.That(MainPageViewModel.PatchNotesUrlFor("11.16"), Is.EqualTo("https://na.leagueoflegends.com/en-us/news/game-updates/patch-11-16-notes/"));
        }
    }
}
