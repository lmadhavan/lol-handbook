using DataDragon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public abstract class FilterableViewModelBase<T> : ViewModelBase, IFilterableViewModel where T : ISupportTags
    {
        private readonly string collectionName;
        private IList<T> collection;
        private string tagFilter;

        protected FilterableViewModelBase(string collectionName)
        {
            this.collectionName = collectionName;
            this.tagFilter = "All";
        }

        protected IList<T> FilteredCollection
        {
            get
            {
                if (collection == null || tagFilter == "All")
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

        public async void LoadData(bool forceReload)
        {
            if (collection != null && !forceReload)
            {
                return;
            }

            IList<T> list = await LoadList(forceReload);

            if (list != null)
            {
                this.collection = list.OrderBy(e => e.Name).ToList();

                List<string> tags = list.SelectMany(e => e.Tags).Distinct().ToList();
                tags.Sort();
                tags.Insert(0, "All");
                this.Tags = tags;

                RaisePropertyChanged(nameof(TagFilter));
                RaisePropertyChanged(collectionName);
                RaisePropertyChanged(nameof(Tags));
            }
        }

        protected abstract Task<IList<T>> LoadList(bool forceReload);
    }
}
