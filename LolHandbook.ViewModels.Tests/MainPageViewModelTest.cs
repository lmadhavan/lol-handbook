using NUnit.Framework;

namespace LolHandbook.ViewModels
{
    [TestFixture]
    public class MainPageViewModelTest
    {
        [Test]
        public void FormatsPatchNotesVersion()
        {
            Assert.That(MainPageViewModel.FormatPatchNotesVersion("1.2"), Is.EqualTo("12"));
            Assert.That(MainPageViewModel.FormatPatchNotesVersion("1.23"), Is.EqualTo("123"));
            Assert.That(MainPageViewModel.FormatPatchNotesVersion("1.23.4"), Is.EqualTo("123"));
        }
    }
}
