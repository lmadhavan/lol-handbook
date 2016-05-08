using DataDragon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LolHandbook.ViewModels
{
    public class ChampionSkinsViewModel : ViewModelBase, IChampionSkinsViewModel
    {
        private readonly IList<ChampionSkin> skins;
        private int currentSkin;

        public ChampionSkinsViewModel(IList<ChampionSkin> skins)
        {
            this.skins = skins;
        }

        public int TotalSkins => skins.Count;
        public IList<Uri> SkinUris => skins.Select(s => s.ImageUri).ToList();

        public int CurrentSkinIndex
        {
            get
            {
                return currentSkin;
            }

            set
            {
                this.currentSkin = value;
                RaisePropertyChanged(nameof(CurrentSkinIndex));
                RaisePropertyChanged(nameof(CurrentSkinDisplayIndex));
                RaisePropertyChanged(nameof(CurrentSkinName));
            }
        }

        public int CurrentSkinDisplayIndex => currentSkin + 1;
        public string CurrentSkinName => skins[currentSkin].Name;
    }
}
