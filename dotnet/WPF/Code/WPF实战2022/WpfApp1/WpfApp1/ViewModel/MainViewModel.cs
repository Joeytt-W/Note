using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new RelayCommand(Show);
        }

        public RelayCommand ShowCommand { get; set; }


        public void Show()
        {
            Name = "µã»÷";
            MessageBox.Show(Name);
        }
    }
}