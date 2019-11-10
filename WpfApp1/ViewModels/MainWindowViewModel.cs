using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Common;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : Common.BindableBase // INotifyPropertyChanged
    {
        private int toggleValue;
        private IPageViewModel _currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return this._currentPageViewModel;
            }
            set
            {
                this._currentPageViewModel = value;
                RaisePropertyChanged();
            }
        }

        private HeaderInfo _HeaderInfo;
        public HeaderInfo HeaderInfo
        {
            get
            {
                return this._HeaderInfo;
            }
            set
            {
                this._HeaderInfo = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            // this.HeaderInfo = "tesettesttest";
            this.HeaderInfo = new HeaderInfo(1, new Rectangle(2, 3, 4, 5));
            this.toggleValue = 0;
            CurrentPageViewModel = new PersonViewModel();
            PageManager.ChangePageFunction = new PageManager.ChangePageDelegate(ChangePage);

        }

        private void ChangePage(IPageViewModel page)
        {
            CurrentPageViewModel = page;
        }

        public DelegateCommand _ToggleButtonCommand;
        protected void ToggleButton(object parameter)
        {
            if(this.toggleValue==0)
            {
                CurrentPageViewModel = new AnimalViewModel();
            }
            else
            {
                CurrentPageViewModel = new PersonViewModel();
            }
            this.toggleValue += 1;
            this.toggleValue &= 1;
        }
        public DelegateCommand ToggleButtonCommand
        {
            get
            {
                if (this._ToggleButtonCommand == null)
                {
                    this._ToggleButtonCommand = new DelegateCommand(ToggleButton);
                }

                return this._ToggleButtonCommand;
            }
        }

        public DelegateCommand _UsersButtonCommand;
        protected void UsersButton(object parameter)
        {
            CurrentPageViewModel = new UsersViewModel();
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

        public DelegateCommand _GridUsersButtonCommand;
        protected void GridUsersButton(object parameter)
        {
            CurrentPageViewModel = new GridUsersViewModel();
        }
        public DelegateCommand GridUsersButtonCommand
        {
            get
            {
                if (this._GridUsersButtonCommand == null)
                {
                    this._GridUsersButtonCommand = new DelegateCommand(GridUsersButton);
                }

                return this._GridUsersButtonCommand;
            }
        }
    }
}
