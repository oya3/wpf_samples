
namespace WpfApp1.ViewModels
{
    class PersonViewModel : IPageViewModel
    {
        public PersonViewModel()
        {

        }

        public DelegateCommand _ButtonCommand;
        protected void Button(object parameter)
        {
            PageManager.ChangePage(new UsersViewModel());
        }

        public DelegateCommand ButtonCommand
        {
            get
            {
                if (this._ButtonCommand == null)
                {
                    this._ButtonCommand = new DelegateCommand(Button);
                }

                return this._ButtonCommand;
            }
        }
 
        public object Person { get; set; } = Models.PersonModel.Instance;

    }
}
