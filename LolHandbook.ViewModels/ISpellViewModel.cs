using System;

namespace LolHandbook.ViewModels
{
    public interface ISpellViewModel
    {
        Uri ImageUri { get; }
        string Name { get; }
        string Description { get; }
        string Cost { get; }
        string Cooldown { get; }
    }
}
