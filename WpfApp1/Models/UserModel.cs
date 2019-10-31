using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    class UserModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Mail { set; get; }
        public string Adderss { get; set; }
        public string Tel { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
