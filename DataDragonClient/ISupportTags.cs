using System.Collections.Generic;

namespace DataDragon
{
    public interface ISupportTags
    {
        string Name { get; }
        IList<string> Tags { get; }
    }
}
