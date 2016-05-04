using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IChampionSkinsViewModel
    {
        int TotalSkins { get; }
        IList<Uri> SkinUris { get; }

        int CurrentSkinIndex { get; set; }
        int CurrentSkinDisplayIndex { get; }
        string CurrentSkinName { get; }
    }
}