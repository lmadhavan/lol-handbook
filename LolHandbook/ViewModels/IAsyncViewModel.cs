using System.ComponentModel;

namespace LolHandbook.ViewModels
{
    public interface IAsyncViewModel : INotifyPropertyChanged
    {
        bool Loading { get; }
        void LoadData(bool forceReload);
    }
}
