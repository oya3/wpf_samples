using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WpfApp1.ViewModels
{
    class UsersViewModel : /*Common.BindableBase,*/ IPageViewModel
    {
        // public ObservableCollection<Models.UserModel> Users { get; set; } = Models.UsersModel.Instance.Users;
        public ObservableCollection<Models.UserModel> Users { get; set; }

        public UsersViewModel(Models.UserModel user = null)
        {
            this.Users = Models.UsersModel.Instance.Users;
            // - ObservableCollectionの中身が変更されたことを検知する方法
            //   https://aroundthedistance.hatenadiary.jp/entry/2014/07/25/200417
            // this.Users.CollectionChanged += Users_CollectionChanged;
            if (null == user)
            {
                SelectedUser = (Models.UserModel)Common.Session.Instance.GetValue("SelectedUser");
            }
            else
            {
                SelectedUser = user;
            }

        }
        /* 
        private void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (Models.UserModel item in e.OldItems)
                    item.PropertyChanged -= MyType_PropertyChanged;
                foreach (Models.UserModel item in e.NewItems)
                    item.PropertyChanged += MyType_PropertyChanged;
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Models.UserModel item in e.NewItems)
                    item.PropertyChanged += MyType_PropertyChanged;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Models.UserModel item in e.OldItems)
                    item.PropertyChanged -= MyType_PropertyChanged;
            }
        }

        private void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //change event hook here
        }
        */

        public Models.UserModel SelectedUser { get; set; } // set Viewの選択状態が通知されているようにできる

        // - How to handle both `MouseLeftButtonUp`and `MouseDoubleClick` mouse events?
        //   https://stackoverflow.com/questions/44062909/how-to-handle-both-mouseleftbuttonupand-mousedoubleclick-mouse-events
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
