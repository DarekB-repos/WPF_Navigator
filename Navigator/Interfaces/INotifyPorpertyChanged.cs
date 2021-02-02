using System.ComponentModel;

namespace Navigator.Interfaces
{
    public interface INotifyPorpertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}
