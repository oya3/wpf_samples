using WpfApp1.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.ViewModels
{
    class UserViewModel : IPageViewModel //,INotifyPropertyChanged
    {
        public object User { get; set; }

        public UserViewModel(UserModel user)
        {
            this.User = user;
        }
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            */
    }
}
