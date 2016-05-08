using System.ComponentModel;
using System.Threading.Tasks;

namespace LolHandbook.ViewModels
{
    public interface IAsyncViewModel : INotifyPropertyChanged
    {
        bool Loading { get; }
        Task LoadData(bool forceReload);
    }
}
