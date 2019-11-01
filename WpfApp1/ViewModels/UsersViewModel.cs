using System.Collections.ObjectModel;

namespace WpfApp1.ViewModels
{
    class UsersViewModel : Common.BindableBase, IPageViewModel
    {
        public ObservableCollection<Models.UserModel> Users { get; set; } = Models.UsersModel.Instance.Users;

        public UsersViewModel()
        {
        }

        public Models.UserModel SelectedUser { get; set; } // set Viewの選択状態が通知されているようにできる

        public DelegateCommand _SelectedUserEventCommand;
        protected void SelectedUserEvent(object parameter)
        {
            Common.Session.Instance.Set("SelectedUser", SelectedUser);
            PageManager.ChangePage(new UserViewModel((Models.UserModel)SelectedUser));
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
