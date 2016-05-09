using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubItemsViewModel : ViewModelBase, IItemsViewModel
    {
        public StubItemsViewModel()
        {
            this.Items = new List<Item>();

            for (int i = 0; i < 25; i++)
            {
                Items.Add(new Item
                {
                    Name = "Item"
                });
            }

            this.Tags = new List<Tag>();
            Tags.Add(new Tag("All"));
            Tags.Add(new Tag("Boots"));
            Tags.Add(new Tag("Health"));
        }

        public IList<Item> Items { get; }
        public IList<Tag> Tags { get; }

        public Tag TagFilter
        {
            get;
            set;
        } = new Tag("All");
    }
}
