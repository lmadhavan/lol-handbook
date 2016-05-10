using DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public abstract class FilterableViewModelBase<T> : ViewModelBase where T : ISupportTags
    {
        public const string TagAll = "All";

        private readonly ILocalizationService localizationService;
        private readonly string collectionName;

        private IList<T> collection;
        private Tag tagFilter;

        protected FilterableViewModelBase(ILocalizationService localizationService, string collectionName)
        {
            this.localizationService = localizationService;
            this.collectionName = collectionName;
        }

        protected IList<T> FilteredCollection
        {
            get
            {
                if (collection == null || tagFilter.Id == TagAll)
                {
                    return collection;
                }

                return collection.Where(c => c.Tags?.Contains(tagFilter.Id) ?? false).ToList();
            }
        }

        public IList<Tag> Tags { get; private set; }

        public Tag TagFilter
        {
            get
            {
                return tagFilter;
            }

            set
            {
                this.tagFilter = value;
                RaisePropertyChanged(nameof(TagFilter));
                RaisePropertyChanged(collectionName);
            }
        }

        public async Task LoadData(bool forceReload)
        {
            if (collection != null && !forceReload)
            {
                return;
            }

            this.Loading = true;
            await localizationService.LoadData(forceReload);
            IList<T> list = await LoadList(forceReload);
            this.Loading = false;

            if (list != null)
            {
                this.collection = list.OrderBy(e => e.Name).ToList();

                List<string> tags = list.SelectMany(e => e.Tags).Distinct().ToList();
                tags.Sort();
                tags.Insert(0, TagAll);

                this.Tags = tags.Select(t => CreateTag(t)).ToList();
                RaisePropertyChanged(nameof(Tags));

                this.TagFilter = CreateTag(TagAll);
            }
        }

        private Tag CreateTag(string id)
        {
            return new Tag(id, localizationService.Lookup(id));
        }

        protected abstract Task<IList<T>> LoadList(bool forceReload);
    }

    public class Tag
    {
        public Tag(string id) : this(id, id)
        {
        }

        public Tag(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
