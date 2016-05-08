using DataDragon;
using NUnit.Framework;
using System.Collections.Generic;
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
            viewModel.LoadData(false).Wait();
        }

        [Test]
        public void ExtractsTagsFromCollection()
        {
            Assert.That(viewModel.Tags, Is.EqualTo(new List<string> { StubViewModel.TagAll, "tag1", "tag2" }).AsCollection);
        }

        [Test]
        public void FiltersCollectionByTag()
        {
            Assert.That(viewModel.TagFilter, Is.EqualTo(StubViewModel.TagAll));
            Assert.That(viewModel.Collection.Count, Is.EqualTo(2));

            viewModel.TagFilter = "tag1";
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
            public StubViewModel() : base("dont-care")
            {
            }

            internal IList<StubElement> Collection => FilteredCollection;

            protected async override Task<IList<StubElement>> LoadList(bool forceReload)
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
