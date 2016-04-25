using DataDragon;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class ChampionsViewModel : ViewModelBase, IChampionsViewModel
    {
        private IList<ChampionSummary> champions;
        private string tagFilter;

        public ChampionsViewModel(DataDragonClient dataDragonClient)
            : base(dataDragonClient)
        {
        }

        public IList<ChampionSummary> Champions
        {
            get
            {
                if (champions == null || tagFilter == "All")
                {
                    return champions;
                }

                return champions.Where(c => c.Tags?.Contains(tagFilter) ?? false).ToList();
            }
        }

        public IList<string> Tags
        {
            get
            {
                if (champions == null)
                {
                    return null;
                }

                List<string> tags = champions.SelectMany(c => c.Tags).Distinct().ToList();
                tags.Sort();
                tags.Insert(0, "All");
                return tags;
            }
        }

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
                RaisePropertyChanged(nameof(Champions));
            }
        }

        protected override async void LoadData(DataDragonClient dataDragonClient)
        {
            this.tagFilter = "All";

            Debug.Write("Fetching champions... ");
            this.champions = await dataDragonClient.GetChampionsAsync();
            Debug.WriteLine("Done.");

            RaisePropertyChanged(nameof(TagFilter));
            RaisePropertyChanged(nameof(Champions));
            RaisePropertyChanged(nameof(Tags));
        }
    }
}
