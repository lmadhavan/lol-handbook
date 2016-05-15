using DataDragon;
using LolHandbook.ViewModels.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    [TestFixture]
    public class FilterableViewModelTest
    {
        private StubViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            this.viewModel = new StubViewModel();
        }

        [Test]
        public void ExtractsTagsFromCollection()
        {
            IList<string> tags = viewModel.Tags.Select(t => t.Id).ToList();
            Assert.That(tags, Is.EqualTo(new List<string> { StubViewModel.TagAll, "tag1", "tag2" }).AsCollection);
        }

        [Test]
        public void FiltersCollectionByTag()
        {
            viewModel.TagFilter = new Tag("tag1");

            Assert.That(viewModel.Groups.Count(), Is.EqualTo(1));

            IEnumerable<StubElement> elements = viewModel.Groups.First();
            Assert.That(elements.Count, Is.EqualTo(2));
            Assert.That(elements.Select(e => e.Name).ToList(), Is.EqualTo(new List<string> { "A1", "A2" }).AsCollection);
        }

        [Test]
        public void GroupsCollectionAlphabetically()
        {
            Assert.That(viewModel.Groups.Select(g => g.Key), Is.EqualTo(new List<string> { "A", "B" }).AsCollection);
        }

        private class StubElement : ISupportTags
        {
            public string Name { get; set; }
            public IList<string> Tags { get; set; }
        }

        private class StubViewModel : FilterableViewModelBase<StubElement>
        {
            public StubViewModel() : base(new StubLocalizationService(), nameof(Groups))
            {
                LoadData(false).Wait();
            }

            internal IEnumerable<IGrouping<string, StubElement>> Groups => FilteredGroups;

            protected async override Task<IList<StubElement>> LoadList()
            {
                return await Task.Run(() => new List<StubElement>
                {
                    new StubElement { Name = "A1", Tags = new List<string> { "tag1" } },
                    new StubElement { Name = "A2", Tags = new List<string> { "tag1" } },
                    new StubElement { Name = "B", Tags = new List<string> { "tag2" } }
                });
            }
        }
    }
}
