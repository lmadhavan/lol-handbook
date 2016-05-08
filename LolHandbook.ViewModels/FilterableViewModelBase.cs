using DataDragon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public abstract class FilterableViewModelBase<T> : ViewModelBase, IFilterableViewModel where T : ISupportTags
    {
        public const string TagAll = "All";

        private readonly string collectionName;
        private IList<T> collection;
        private string tagFilter;

        protected FilterableViewModelBase(string collectionName)
        {
            this.collectionName = collectionName;
            this.tagFilter = TagAll;
        }

        protected IList<T> FilteredCollection
        {
            get
            {
                if (collection == null || tagFilter == TagAll)
                {
                    return collection;
                }

                return collection.Where(c => c.Tags?.Contains(tagFilter) ?? false).ToList();
            }
        }

        public IList<string> Tags { get; private set; }

        public string TagFilter
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

        public override async Task LoadData(bool forceReload)
        {
            if (collection != null && !forceReload)
            {
                return;
            }

            this.Loading = true;
            IList<T> list = await LoadList(forceReload);
            this.Loading = false;

            if (list != null)
            {
                this.collection = list.OrderBy(e => e.Name).ToList();

                List<string> tags = list.SelectMany(e => e.Tags).Distinct().ToList();
                tags.Sort();
                tags.Insert(0, TagAll);
                this.Tags = tags;

                RaisePropertyChanged(nameof(TagFilter));
                RaisePropertyChanged(collectionName);
                RaisePropertyChanged(nameof(Tags));
            }
        }

        protected abstract Task<IList<T>> LoadList(bool forceReload);
    }
}
