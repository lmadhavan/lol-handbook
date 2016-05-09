using DataDragon;
using LolHandbook.ViewModels.Services;
using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase, IItemDetailViewModel
    {
        private readonly Item item;

        public ItemDetailViewModel(DataDragonService dataDragonService, string id)
            : this(dataDragonService, dataDragonService.GetItem(id))
        {
        }

        public ItemDetailViewModel(DataDragonService dataDragonService, Item item)
        {
            this.item = item;

            this.Requires = new List<Item>();
            if (item.Requires != null)
            {
                foreach (string id in item.Requires)
                {
                    Requires.Add(dataDragonService.GetItem(id));
                }
            }

            this.BuildsInto = new List<Item>();
            if (item.BuildsInto != null)
            {
                foreach (string id in item.BuildsInto)
                {
                    BuildsInto.Add(dataDragonService.GetItem(id));
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