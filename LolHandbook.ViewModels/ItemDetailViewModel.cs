using DataDragon;
using LolHandbook.ViewModels.Services;
using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly IDataDragonService dataDragonService;
        private string id;
        private Item item;

        public ItemDetailViewModel(IDataDragonService dataDragonService)
        {
            this.dataDragonService = dataDragonService;
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

                    this.Item = dataDragonService.GetItem(id);
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
                    this.item = value;
                    RaisePropertyChanged(nameof(Item));
                    LoadData();
                }
            }
        }

        public string Name => item?.Name;
        public Uri ImageUri => item?.ImageUri;
        public string Cost => item?.Cost.Total.ToString();
        public string Description => HtmlSanitizer.Sanitize(item?.Description);
        public string Plaintext => HtmlSanitizer.Sanitize(item?.Plaintext);

        public IList<Item> Requires { get; private set; }
        public IList<Item> BuildsInto { get; private set; }

        private void LoadData()
        {
            LoadRequires();
            LoadBuildsInto();

            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(ImageUri));
            RaisePropertyChanged(nameof(Cost));
            RaisePropertyChanged(nameof(Description));
            RaisePropertyChanged(nameof(Plaintext));
            RaisePropertyChanged(nameof(Requires));
            RaisePropertyChanged(nameof(BuildsInto));
        }

        private void LoadRequires()
        {
            this.Requires = new List<Item>();
            if (item.Requires != null)
            {
                foreach (string id in item.Requires)
                {
                    Requires.Add(dataDragonService.GetItem(id));
                }
            }
        }

        private void LoadBuildsInto()
        {
            this.BuildsInto = new List<Item>();
            if (item.BuildsInto != null)
            {
                foreach (string id in item.BuildsInto)
                {
                    BuildsInto.Add(dataDragonService.GetItem(id));
                }
            }
        }
    }
}