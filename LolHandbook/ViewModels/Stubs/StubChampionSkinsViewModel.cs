using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels.Stubs
{
    public class StubChampionSkinsViewModel : ViewModelBase, IChampionSkinsViewModel
    {
        public StubChampionSkinsViewModel()
        {
            this.SkinUris = new List<Uri>() { null, null, null };
        }

        public int TotalSkins => 3;
        public IList<Uri> SkinUris { get; }

        public int CurrentSkinIndex { get; set; }
        public int CurrentSkinDisplayIndex { get; }
        public string CurrentSkinName => "default";
    }
}
