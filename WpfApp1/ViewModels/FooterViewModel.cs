
namespace WpfApp1.ViewModels
{
    class FooterViewModel : UsersViewModel
    {
        public FooterViewModel(Models.UserModel user = null) : base(user)
        {
        }
        public FooterViewModel() : base(null)
        {
        }
        /*
        public DelegateCommand _UsersButtonCommand;
        protected void UsersButton(object parameter)
        {

        }
        public DelegateCommand UsersButtonCommand
        {
            get
            {
                if (this._UsersButtonCommand == null)
                {
                    this._UsersButtonCommand = new DelegateCommand(UsersButton);
                }

                return this._UsersButtonCommand;
            }
        }
        */
    }
}
