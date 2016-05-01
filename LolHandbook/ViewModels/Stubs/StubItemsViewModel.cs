using DataDragon;
using System.Collections.Generic;
using System;

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

            this.Tags = new List<string>();
            Tags.Add("All");
            Tags.Add("Boots");
            Tags.Add("Health");
        }

        public IList<Item> Items { get; }
        public IList<string> Tags { get; }

        public string TagFilter
        {
            get;
            set;
        } = "All";

        public void LoadData(bool forceReload)
        {
        }
    }
}
