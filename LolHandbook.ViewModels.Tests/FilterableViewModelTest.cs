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
            Assert.That(viewModel.TagFilter.Id, Is.EqualTo(StubViewModel.TagAll));
            Assert.That(viewModel.Collection.Count, Is.EqualTo(2));

            viewModel.TagFilter = new Tag("tag1");
            Assert.That(viewModel.Collection.Count, Is.EqualTo(1));
            Assert.That(viewModel.Collection[0].Name, Is.EqualTo("element1"));
        }

        private class StubElement : ISupportTags
        {
            public string Name { get; set; }
            public IList<string> Tags { get; set; }
        }

        private class StubViewModel : FilterableViewModelBase<StubElement>
        {
            public StubViewModel() : base(new StubLocalizationService(), "dont-care")
            {
                LoadData(false).Wait();
            }

            internal IList<StubElement> Collection => FilteredCollection;

            protected async override Task<IList<StubElement>> LoadList()
            {
                return await Task.Run(() => new List<StubElement>
                {
                    new StubElement { Name = "element1", Tags = new List<string> { "tag1" } },
                    new StubElement { Name = "element2", Tags = new List<string> { "tag2" } }
                });
            }
        }
    }
}
