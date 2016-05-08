using DataDragon;
using System;
using System.Collections.Generic;

namespace LolHandbook.ViewModels
{
    public interface IItemDetailViewModel
    {
        string Name { get; }
        Uri ImageUri { get; }
        string Cost { get; }
        string Description { get; }
        string Plaintext { get; }

        IList<Item> Requires { get; }
        IList<Item> BuildsInto { get; }
    }
}