using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class UsersViewModel : IPageViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<UserModel> Users { get; set; } = UsersModel.Instance.Users;

        public UsersViewModel()
        {
        }

        public UserModel SelectedUser { get; set; } // set Viewの選択状態が通知されているようにできる

        public DelegateCommand _SelectedUserEventCommand;
        protected void SelectedUserEvent(object parameter)
        {
            Session.Instance.Set("SelectedUser", SelectedUser);
            PageManager.ChangePage(new UserViewModel((UserModel)SelectedUser));
        }
        public DelegateCommand SelectedUserEventCommand
        {
            get
            {
                if (this._SelectedUserEventCommand == null)
                {
                    this._SelectedUserEventCommand = new DelegateCommand(SelectedUserEvent);
                }

                return this._SelectedUserEventCommand;
            }
        }
    }
}
