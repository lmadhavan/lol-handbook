using System.ComponentModel;

namespace LolHandbook.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private bool loading;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Loading
        {
            get
            {
                return loading;
            }

            protected set
            {
                this.loading = value;
                RaisePropertyChanged(nameof(Loading));
            }
        }
    }
}
