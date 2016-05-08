using System;

namespace LolHandbook.ViewModels
{
    public interface ISpellViewModel
    {
        Uri ImageUri { get; }
        string Name { get; }
        string Description { get; }
        string AdditionalInfo { get; }
        string Cooldown { get; }
    }
}
