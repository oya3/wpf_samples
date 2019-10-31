using System.Collections.ObjectModel;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class UsersViewModel : IPageViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; } = UsersModel.Instance.Users;


        public UsersViewModel()
        {
        }

        public UserViewModel SelectedUser { get; set; }

        public DelegateCommand _SelectedUserEventCommand;
        protected void SelectedUserEvent(object parameter)
        {
            Session.Instance.Set("SelectedItem", parameter);
            PageManager.Go("GoTo4Screen", this.SelectedUser);
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
