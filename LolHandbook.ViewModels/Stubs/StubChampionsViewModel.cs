using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionsViewModel : ViewModelBase, IChampionsViewModel
    {
        public StubChampionsViewModel()
        {
            this.Champions = new List<ChampionSummary>();

            for (int i = 0; i < 25; i++)
            {
                Champions.Add(new ChampionSummary
                {
                    Name = "Champion"
                });
            }

            this.Tags = new List<Tag>();
            Tags.Add(new Tag("All"));
            Tags.Add(new Tag("Fighter"));
            Tags.Add(new Tag("Tank"));
        }

        public IList<ChampionSummary> Champions { get; }
        public IList<Tag> Tags { get; }

        public Tag TagFilter
        {
            get;
            set;
        } = new Tag("All");
    }
}
