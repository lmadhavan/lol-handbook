using System;
using System.Collections.Generic;
using DataDragon;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubItemDetailViewModel : IItemDetailViewModel
    {
        public string Name => "Item";
        public Uri ImageUri => null;
        public string Cost => "1000";
        public string Description => "+100 Attack Damage\n+100 Health";
        public string Plaintext => "An excellent item";

        public IList<Item> Requires => new List<Item>() {
            new Item { Name = "Required Item 1" },
            new Item { Name = "Required Item 2" }
        };
        public IList<Item> BuildsInto => new List<Item>() {
            new Item { Name = "Builds Into Item 1" },
            new Item { Name = "Builds Into Item 2" }
        };
    }
}
