using DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public class ChampionDetailViewModel : ViewModelBase
    {
        private readonly IDataDragonClient dataDragonClient;
        private string id;
        private ChampionSummary summary;

        public ChampionDetailViewModel(IDataDragonClient dataDragonClient)
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
                    Set(value, null);
                }
            }
        }

        public ChampionSummary Summary
        {
            get
            {
                return summary;
            }

            set
            {
                if (summary != value)
                {
                    Set(value?.Id, value);
                }
            }
        }

        private void Set(string id, ChampionSummary summary)
        {
            this.id = id;
            RaisePropertyChanged(nameof(Id));

            this.summary = summary;
            RaisePropertyChanged(nameof(Summary));

            this.Detail = null;
            this.Spells = null;

            RaiseAllPropertiesChanged();
            if (id != null)
            {
                LoadData(false);
            }
        }

        private ChampionDetail Detail { get; set; }

        public Uri IconUri => Resolve(c => c.ImageUri);

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

        public string Lore => HtmlSanitizer.Sanitize(Detail?.Lore);

        public IList<ISpellViewModel> Spells { get; private set; }

        public ChampionStatsViewModel Stats
        {
            get
            {
                ChampionStats stats = Resolve(c => c.Stats);
                return stats == null ? null : new ChampionStatsViewModel(stats);
            }
        }

        public string AllyTips => Format(Detail?.AllyTips);
        public string EnemyTips => Format(Detail?.EnemyTips);

        public Uri DefaultSkinUri => Detail?.Skins[0].ImageUri;
        public IList<ChampionSkin> Skins => Detail?.Skins;

        private T Resolve<T>(Func<ChampionBase, T> accessor)
        {
            if (Detail != null) return accessor(Detail);
            if (Summary != null) return accessor(Summary);
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

        public async void LoadData(bool forceReload)
        {
            if (Detail != null && !forceReload)
            {
                return;
            }

            this.Loading = true;
            this.Detail = await Task.Run(() => dataDragonClient.GetChampionDetailAsync(id));
            this.Loading = false;

            if (Detail == null)
            {
                return;
            }

            this.Spells = new List<ISpellViewModel>();
            Spells.Add(new ChampionPassiveViewModel(Detail.Passive));
            foreach (ChampionSpell championSpell in Detail.Spells)
            {
                Spells.Add(new ChampionSpellViewModel(championSpell));
            }

            if (Skins.Count > 0)
            {
                // Replace "default" skin name with champion name
                Skins[0].Name = Name;
            }

            RaiseAllPropertiesChanged();
        }

        private void RaiseAllPropertiesChanged()
        {
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