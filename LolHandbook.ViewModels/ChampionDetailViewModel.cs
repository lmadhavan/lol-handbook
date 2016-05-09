using DataDragon;
using LolHandbook.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionDetailViewModel : ViewModelBase, IChampionDetailViewModel
    {
        private readonly DataDragonService dataDragonService;
        private readonly string id;

        public ChampionDetailViewModel(DataDragonService dataDragonService, string id)
        {
            this.dataDragonService = dataDragonService;
            this.id = id;
        }

        public ChampionDetailViewModel(DataDragonService dataDragonService, ChampionBase champion)
            : this(dataDragonService, champion.Id)
        {
            this.ChampionBase = champion;
        }

        private ChampionBase ChampionBase { get; }
        private ChampionDetail ChampionDetail { get; set; }

        public Uri IconUri => Resolve(c => c.ImageUri);

        public string Id => id;
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

        public Uri DefaultSkinUri => ChampionDetail?.Skins[0].ImageUri;
        public IList<ChampionSkin> Skins => ChampionDetail?.Skins;

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

        public override async Task LoadData(bool forceReload)
        {
            if (ChampionDetail != null && !forceReload)
            {
                return;
            }

            this.Loading = true;
            this.ChampionDetail = await Task.Run(() => dataDragonService.GetChampionAsync(id));
            this.Loading = false;

            if (ChampionDetail == null)
            {
                return;
            }

            this.Spells = new List<ISpellViewModel>();
            Spells.Add(new ChampionPassiveViewModel(ChampionDetail.Passive));
            foreach (ChampionSpell championSpell in ChampionDetail.Spells)
            {
                Spells.Add(new ChampionSpellViewModel(championSpell));
            }

            if (Skins.Count > 0)
            {
                // Replace "default" skin name with champion name
                Skins[0].Name = Name;
            }

            RaisePropertyChanged(nameof(IconUri));
            RaisePropertyChanged(nameof(DefaultSkinUri));
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