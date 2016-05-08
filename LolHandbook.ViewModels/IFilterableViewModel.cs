using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IFilterableViewModel : IAsyncViewModel
    {
        IList<string> Tags { get; }
        string TagFilter { get; set; }
    }
}
