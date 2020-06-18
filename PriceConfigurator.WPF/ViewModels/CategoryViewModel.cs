using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PriceConfigurator.WPF.ViewModels
{
    class CategoryViewModel : INotifyPropertyChanged
    {
        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
