using DataDragon;
using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly IDataDragonClient dataDragonClient;
        private string id;
        private Item item;

        public ItemDetailViewModel(IDataDragonClient dataDragonClient)
        {
            this.dataDragonClient = dataDragonClient;
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                if (id != value)
                {
                    this.id = value;
                    RaisePropertyChanged(nameof(Id));

                    this.Item = null;
                    RaisePropertyChanged(nameof(Item));

                    LoadData(id);
                }
            }
        }

        public Item Item
        {
            get
            {
                return item;
            }

            set
            {
                if (item != value)
                {
                    this.id = null;
                    RaisePropertyChanged(nameof(Id));

                    this.item = value;
                    RaisePropertyChanged(nameof(Item));

                    LoadData(null);
                }
            }
        }

        public string Name => item?.Name;
        public Uri ImageUri => item?.ImageUri;
        public string Cost => item?.Cost.Total.ToString();
        public string Description => item?.Description;
        public string Plaintext => item?.Plaintext;

        public IList<Item> Requires { get; private set; }
        public IList<Item> BuildsInto { get; private set; }

        private async void LoadData(string id)
        {
            IDictionary<string, Item> items = await dataDragonClient.GetItemsAsync();

            if (id != null)
            {
                if (items.ContainsKey(id))
                {
                    this.item = items[id];
                    RaisePropertyChanged(nameof(Item));
                } else
                {
                    return;
                }
            }

            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(ImageUri));
            RaisePropertyChanged(nameof(Cost));
            RaisePropertyChanged(nameof(Description));
            RaisePropertyChanged(nameof(Plaintext));

            LoadRequires(items);
            LoadBuildsInto(items);
        }

        private void LoadRequires(IDictionary<string, Item> items)
        {
            this.Requires = new List<Item>();

            if (item?.Requires != null)
            {
                foreach (string id in item.Requires)
                {
                    if (items.ContainsKey(id))
                    {
                        Requires.Add(items[id]);
                    }
                }
            }

            RaisePropertyChanged(nameof(Requires));
        }

        private void LoadBuildsInto(IDictionary<string, Item> items)
        {
            this.BuildsInto = new List<Item>();

            if (item?.BuildsInto != null)
            {
                foreach (string id in item.BuildsInto)
                {
                    if (items.ContainsKey(id))
                    {
                        BuildsInto.Add(items[id]);
                    }
                }
            }

            RaisePropertyChanged(nameof(BuildsInto));
        }
    }
}