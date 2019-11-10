using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    /*
    public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
    {
        var sortableList = new List<T>(collection);
        sortableList.Sort(comparison);

        for (int i = 0; i < sortableList.Count; i++)
        {
            collection.Move(collection.IndexOf(sortableList[i]), i);
        }
    }
    */

    class UsersModel //: Common.BindableBase
    {
        private static readonly UsersModel instance = new UsersModel();
        public ObservableCollection<UserModel> Users;
        public bool StopWorker { get; set; } = false;

        private UsersModel()
        {
            this.Users = new ObservableCollection<UserModel>();
            for (int index = 0; index < 100; index++)
            {
                var user = new UserModel();
                user.ID = index;
                user.Name = string.Format("{0:D3}", index) + "name";
                user.Mail = string.Format("{0:D3}", index) + "mail";
                user.Address = string.Format("{0:D3}", index) + "address";
                user.Tel = string.Format("{0:D2}", index) + "-000-0000";
                this.Users.Add(user);
            }

            // Task.Run(() => this.Worker());
        }

        private void Worker()
        {
            int mode = 0; // 0,1:順番入れ替え、1:削除、2:追加
            while (false == this.StopWorker)
            {
                Thread.Sleep(2000);
                if (0 == mode)
                {
                    //this.Users.Sort((a, b) => { return a.CompareTo(b); });
                    // this.Users = new ObservableCollection<UserModel>(this.Users.OrderByDescending(n => n.ID));
                    mode++;
                }
                else if (1 == mode)
                {

                    // this.Users = new ObservableCollection<UserModel>(this.Users.OrderBy(n => n.ID));
                    mode++;
                    mode = 0;
                }
            }
        }

        public static UsersModel Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
