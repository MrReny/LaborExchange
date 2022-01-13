using System.ComponentModel;
using System.Runtime.CompilerServices;
using LaborExchange.Commons;

namespace LaborExchange.Client.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}