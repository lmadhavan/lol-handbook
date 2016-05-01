using System.ComponentModel;

namespace LolHandbook.ViewModels
{
    public interface IAsyncViewModel : INotifyPropertyChanged
    {
        void LoadData(bool forceReload);
    }
}
