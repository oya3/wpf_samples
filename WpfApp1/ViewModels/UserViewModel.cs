
namespace WpfApp1.ViewModels
{
    class UserViewModel : IPageViewModel
    {
        public object User { get; set; }

        public UserViewModel(Models.UserModel user)
        {
            this.User = user;
        }
    }
}
