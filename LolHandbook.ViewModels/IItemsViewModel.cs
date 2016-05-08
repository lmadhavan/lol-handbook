using DataDragon;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IItemsViewModel : IFilterableViewModel
    {
        IList<Item> Items { get; }
    }
}
