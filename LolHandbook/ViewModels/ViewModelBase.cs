using DataDragon;
using System.ComponentModel;

namespace LolHandbook.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected ViewModelBase(DataDragonClient dataDragonClient)
        {
            LoadData(dataDragonClient);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected abstract void LoadData(DataDragonClient dataDragonClient);
    }
}
