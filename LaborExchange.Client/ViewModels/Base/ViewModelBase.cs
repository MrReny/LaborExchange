using System.ComponentModel;
using System.Runtime.CompilerServices;
using LaborExchange.Client.Annotations;

namespace LaborExchange.Client
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