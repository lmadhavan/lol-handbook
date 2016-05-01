using DataDragon;
using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase, IItemDetailViewModel
    {
        private readonly Item item;

        public ItemDetailViewModel(CachingDataDragonClient dataDragonClient, string id)
            : this(dataDragonClient, dataDragonClient.GetItem(id))
        {
        }

        public ItemDetailViewModel(CachingDataDragonClient dataDragonClient, Item item)
        {
            this.item = item;

            this.Requires = new List<Item>();
            if (item.Requires != null)
            {
                foreach (string id in item.Requires)
                {
                    Requires.Add(dataDragonClient.GetItem(id));
                }
            }

            this.BuildsInto = new List<Item>();
            if (item.BuildsInto != null)
            {
                foreach (string id in item.BuildsInto)
                {
                    BuildsInto.Add(dataDragonClient.GetItem(id));
                }
            }
        }

        public string Name => item.Name;
        public Uri ImageUri => item.ImageUri;
        public string Cost => item.Cost.Total.ToString();
        public string Description => HtmlSanitizer.Sanitize(item.Description);
        public string Plaintext => HtmlSanitizer.Sanitize(item.Plaintext);

        public IList<Item> Requires { get; private set; }
        public IList<Item> BuildsInto { get; private set; }
    }
}