using LolHandbook.DataDragon;
using LolHandbook.ViewModels.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public abstract class FilterableViewModelBase<T> : ViewModelBase where T : ISupportTags
    {
        public static readonly Tag TagAll = new Tag("All");

        private readonly ILocalizationService localizationService;
        private readonly string collectionName;

        private IList<T> collection;
        private Tag tagFilter;

        protected FilterableViewModelBase(ILocalizationService localizationService, string collectionName)
        {
            this.localizationService = localizationService;
            this.collectionName = collectionName;
        }

        protected IEnumerable<IGrouping<string, T>> FilteredGroups => FilteredCollection?.GroupBy(e => ExtractGroupKey(e));

        private IList<T> FilteredCollection
        {
            get
            {
                if (collection == null || tagFilter == TagAll)
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
                if (tagFilter != value)
                {
                    this.tagFilter = value;
                    RaisePropertyChanged(nameof(TagFilter));
                    RaisePropertyChanged(collectionName);
                }
            }
        }

        public List<T> Search(string text)
        {
            List<T> results = new List<T>();
            text = text.ToLower();

            if (collection != null)
            {
                foreach (T item in collection)
                {
                    if (item.Name.ToLower().Contains(text))
                    {
                        results.Add(item);
                    }
                }
            }

            return results;
        }

        public async Task LoadData(bool forceReload)
        {
            if (collection != null && !forceReload)
            {
                return;
            }

            this.Loading = true;
            await localizationService.LoadData();
            IList<T> list = await LoadList();
            this.Loading = false;

            if (list != null)
            {
                this.collection = list.Where(e => e.Name.Length > 0).OrderBy(e => e.Name).ToList();

                List<string> tagIds = list.SelectMany(e => e.Tags).Distinct().ToList();

                List<Tag> tags = tagIds.Select(t => CreateTag(t)).OrderBy(t => t.Name).ToList();
                tags.Insert(0, TagAll);

                this.Tags = tags;
                RaisePropertyChanged(nameof(Tags));

                this.tagFilter = TagAll;
                RaisePropertyChanged(nameof(TagFilter));
                RaisePropertyChanged(collectionName);
            }
        }

        private Tag CreateTag(string id)
        {
            return new Tag(id, localizationService.Lookup(id));
        }

        private string ExtractGroupKey(T value)
        {
            return value.Name.Substring(0, 1).ToUpper();
        }

        protected abstract Task<IList<T>> LoadList();
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

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Tag && ((Tag)obj).Id == this.Id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
