using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NarfuSchedule.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel ()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}