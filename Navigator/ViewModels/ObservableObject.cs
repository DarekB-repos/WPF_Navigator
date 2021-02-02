using Navigator.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Navigator.ViewModels
{
    public class ObservableObject : INotifyPorpertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged(params string[] propertyNames)
        {
            if (!(PropertyChanged is null))
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
        
        protected virtual bool SetRef<T>(ref T backingField,T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;
            backingField = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}
