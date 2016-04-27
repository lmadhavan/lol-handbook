using DataDragon;
using System.Collections.Generic;
using System;
using Windows.UI.Xaml;

namespace LolHandbook.ViewModels
{
    public class ChampionDetailViewModel : ViewModelBase, IChampionDetailViewModel
    {
        public ChampionDetailViewModel(DataDragonClient dataDragonClient, string id)
        {
            LoadData(dataDragonClient, id);
        }

        public ChampionDetailViewModel(DataDragonClient dataDragonClient, ChampionBase champion)
        {
            this.ChampionBase = champion;
            LoadData(dataDragonClient, champion.Id);
        }

        private ChampionBase ChampionBase { get; }
        private ChampionDetail ChampionDetail { get; set; }

        public Uri ImageUri => Resolve(c => c.ImageUri);
        public string Name => Resolve(c => c.Name);
        public string Title => Resolve(c => c.Title);
        public string Blurb => HtmlSanitizer.Sanitize(Resolve(c => c.Blurb));

        public string Role
        {
            get
            {
                IList<string> tags = Resolve(c => c.Tags);
                return tags == null ? null : "Role: " + string.Join(", ", tags);
            }
        }

        public Visibility MoreButtonVisible => Lore == null ? Visibility.Collapsed : Visibility.Visible;
        public string Lore => HtmlSanitizer.Sanitize(ChampionDetail?.Lore);

        public IList<ISpellViewModel> Spells { get; private set; }

        private T Resolve<T>(Func<ChampionBase, T> accessor)
        {
            if (ChampionDetail != null) return accessor(ChampionDetail);
            if (ChampionBase != null) return accessor(ChampionBase);
            return default(T);
        }

        private async void LoadData(DataDragonClient dataDragonClient, string id)
        {
            this.ChampionDetail = await dataDragonClient.GetChampion(id);

            this.Spells = new List<ISpellViewModel>();
            Spells.Add(new ChampionPassiveViewModel(ChampionDetail.Passive));
            foreach (ChampionSpell championSpell in ChampionDetail.Spells)
            {
                Spells.Add(new ChampionSpellViewModel(championSpell));
            }

            RaisePropertyChanged(nameof(ImageUri));
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(Title));
            RaisePropertyChanged(nameof(Role));
            RaisePropertyChanged(nameof(Blurb));
            RaisePropertyChanged(nameof(MoreButtonVisible));
            RaisePropertyChanged(nameof(Lore));
            RaisePropertyChanged(nameof(Spells));
        }
    }
}