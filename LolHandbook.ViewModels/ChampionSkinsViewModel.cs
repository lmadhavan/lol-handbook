using LolHandbook.DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class ChampionSkinsViewModel : ViewModelBase
    {
        private IList<ChampionSkin> skins;
        private int currentSkinIndex;

        public IList<ChampionSkin> Skins
        {
            get
            {
                return skins;
            }

            set
            {
                if (skins != value)
                {
                    this.skins = value;
                    RaisePropertyChanged(nameof(Skins));
                    RaisePropertyChanged(nameof(TotalSkins));
                    RaisePropertyChanged(nameof(SkinUris));
                }

                this.CurrentSkinIndex = 0;
            }
        }

        public string CurrentSkinName => skins[currentSkinIndex].Name;

        public int TotalSkins => skins.Count;
        public int CurrentSkinDisplayIndex => currentSkinIndex + 1;

        public int CurrentSkinIndex
        {
            get
            {
                return currentSkinIndex;
            }

            set
            {
                this.currentSkinIndex = value;
                RaisePropertyChanged(nameof(CurrentSkinIndex));
                RaisePropertyChanged(nameof(CurrentSkinDisplayIndex));
                RaisePropertyChanged(nameof(CurrentSkinName));
            }
        }

        public IList<Uri> SkinUris => skins.Select(s => s.ImageUri).ToList();
        public Uri CurrentSkinUri => skins[currentSkinIndex].ImageUri;
    }
}
