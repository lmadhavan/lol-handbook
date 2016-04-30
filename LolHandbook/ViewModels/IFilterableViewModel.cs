using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IFilterableViewModel
    {
        IList<string> Tags { get; }
        string TagFilter { get; set; }
    }
}
