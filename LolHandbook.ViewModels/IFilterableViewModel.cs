using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IFilterableViewModel : IAsyncViewModel
    {
        IList<Tag> Tags { get; }
        Tag TagFilter { get; set; }
    }

    public class Tag
    {
        public Tag(string id) : this(id, id)
        {
        }

        public Tag(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
