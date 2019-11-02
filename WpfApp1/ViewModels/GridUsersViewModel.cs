using System.Collections.ObjectModel;

namespace WpfApp1.ViewModels
{
    class GridUsersViewModel : UsersViewModel
    {
        public GridUsersViewModel(Models.UserModel user = null) : base(user)
        {
        }
    }
}
