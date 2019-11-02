using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    class UsersModel : Common.BindableBase
    {
        private static readonly UsersModel instance = new UsersModel();
        public ObservableCollection<UserModel> Users;
        private UsersModel()
        {
            this.Users = new ObservableCollection<UserModel>();
            for (int index = 0; index <= 100; index++)
            {
                var user = new UserModel();
                user.ID = index;
                user.Name = string.Format("{0:D3}", index) + "name";
                user.Mail = string.Format("{0:D3}", index) + "mail";
                user.Address = string.Format("{0:D3}", index) + "address";
                user.Tel = string.Format("{0:D2}", index) + "-000-0000";
                this.Users.Add(user);
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
