using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionsViewModel : IChampionsViewModel
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

            this.Tags = new List<string>();
            Tags.Add("All");
            Tags.Add("Fighter");
            Tags.Add("Tank");
        }

        public IList<ChampionSummary> Champions { get; }
        public IList<string> Tags { get; }

        public string TagFilter
        {
            get;
            set;
        } = "All";
    }
}
