using DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class ChampionDetailViewModel : ViewModelBase, IChampionDetailViewModel
    {
        public ChampionDetailViewModel(CachingDataDragonClient dataDragonClient, string id)
        {
            LoadData(dataDragonClient, id);
        }

        public ChampionDetailViewModel(CachingDataDragonClient dataDragonClient, ChampionBase champion)
            : this(dataDragonClient, champion.Id)
        {
            this.ChampionBase = champion;
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

        public string Lore => HtmlSanitizer.Sanitize(ChampionDetail?.Lore);

        public IList<ISpellViewModel> Spells { get; private set; }

        public ChampionStatsViewModel Stats
        {
            get
            {
                ChampionStats stats = Resolve(c => c.Stats);
                return stats == null ? null : new ChampionStatsViewModel(stats);
            }
        }

        public string AllyTips => Format(ChampionDetail?.AllyTips);
        public string EnemyTips => Format(ChampionDetail?.EnemyTips);


        private T Resolve<T>(Func<ChampionBase, T> accessor)
        {
            if (ChampionDetail != null) return accessor(ChampionDetail);
            if (ChampionBase != null) return accessor(ChampionBase);
            return default(T);
        }

        private string Format(IList<string> list)
        {
            if (list == null)
            {
                return null;
            }

            return HtmlSanitizer.Sanitize(string.Join("\n", list.Select(str => "\u2022 " + str)));
        }

        private async void LoadData(CachingDataDragonClient dataDragonClient, string id)
        {
            this.ChampionDetail = await dataDragonClient.GetChampionAsync(id);

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
            RaisePropertyChanged(nameof(Lore));
            RaisePropertyChanged(nameof(Spells));
            RaisePropertyChanged(nameof(Stats));
            RaisePropertyChanged(nameof(AllyTips));
            RaisePropertyChanged(nameof(EnemyTips));
        }
    }
}