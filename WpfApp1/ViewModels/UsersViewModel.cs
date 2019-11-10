using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WpfApp1.ViewModels
{
    class UsersViewModel : Common.BindableBase, IPageViewModel
    {
        // public ObservableCollection<Models.UserModel> Users { get; set; } = Models.UsersModel.Instance.Users;
        public ObservableCollection<Models.UserModel> Users { get; set; }
        public CollectionViewSource UsersViewSource { get; private set; }
        public bool StopWorker { get; set; } = false;
        private SynchronizationContext _mainContext;

        public UsersViewModel(Models.UserModel user = null)
        {
            this.Users = Models.UsersModel.Instance.Users;
            this.UsersViewSource = new CollectionViewSource()
            {
                Source = this.Users
            };
            this.UserIDSort(ListSortDirection.Descending);
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
            _mainContext = SynchronizationContext.Current;
            Task.Run(() => this.Worker());
        }

        public void Worker()
        {
            int mode = 0; // 0,1:順番入れ替え、1:削除、2:追加
            while (false == this.StopWorker)
            {
                Thread.Sleep(2000);
                if (0 == mode)
                {
                    //this.Users.Sort((a, b) => { return a.CompareTo(b); });
                    _mainContext.Post(_ =>
                    {
                        this.Users = new ObservableCollection<Models.UserModel>(Models.UsersModel.Instance.Users.OrderByDescending(n => n.ID));
                        RaisePropertyChanged("Users");
                    }, null);
                    mode++;
                }
                else if (1 == mode)
                {
                    // this.Users = new ObservableCollection<UserModel>(this.Users.OrderBy(n => n.ID));
                    _mainContext.Post(_ =>
                    {
                        this.Users = new ObservableCollection<Models.UserModel>(Models.UsersModel.Instance.Users.OrderBy(n => n.ID));
                        RaisePropertyChanged("Users");
                    }, null);
                    mode++;
                    mode = 0;
                }
                /*
                if (0 == mode)
                {
                    _mainContext.Post(_ => this.UserIDSort(ListSortDirection.Ascending), null);
                    mode++;
                }
                else if (1 == mode)
                {
                    _mainContext.Post(_ => this.UserIDSort(ListSortDirection.Descending), null);
                    mode++;
                    mode = 0;
                }
                */
            }

        }

        public void UserIDSort(ListSortDirection direction)
        {
            UsersViewSource.SortDescriptions.Clear();
            UsersViewSource.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
            //aisePropertyChanged("UsersViewSource");
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
