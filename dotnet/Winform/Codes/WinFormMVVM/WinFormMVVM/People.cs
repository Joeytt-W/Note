using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormMVVM
{
    public class People : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private string address;

        public string Name
        {
            get =>name;
            set
            {
                name = value; 
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
