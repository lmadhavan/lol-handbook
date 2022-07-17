using System.Collections.Generic;

namespace LolHandbook.DataDragon
{
    public interface ISupportTags
    {
        string Name { get; }
        IList<string> Tags { get; }
    }
}
