using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace WpfTreeView
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
