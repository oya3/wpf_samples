﻿using System.Collections.ObjectModel;
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
            this.Users.Add(new UserModel() { ID=0, Name = "00 John Doe", Mail = "john@doe-family.com", Adderss = "000address", Tel = "000-000-000" });
            this.Users.Add(new UserModel() { ID=1, Name = "01 Jane Doe", Mail = "jane@doe-family.com", Adderss = "111address", Tel = "111-111-111" });
            this.Users.Add(new UserModel() { ID=2, Name = "02 Sammy Doe", Mail = "sammy.doe@gmail.com", Adderss = "222address", Tel = "222-222-222" });
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
