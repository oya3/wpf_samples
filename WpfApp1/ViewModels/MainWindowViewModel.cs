using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<IPageViewModel> _pageViewModels;
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        private IPageViewModel _currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                this.SetProperty(ref this._currentPageViewModel, value);
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void OnGo1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }
        private void OnGo2Screen(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }
        private void OnGo3Screen(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }
        private void OnGo4Screen(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new PersonViewModel());
            PageViewModels.Add(new AnimalViewModel());
            PageViewModels.Add(new UsersViewModel());
            PageViewModels.Add(new UserViewModel());

            CurrentPageViewModel = PageViewModels[2];

            PageManager.Add("GoTo1Screen", OnGo1Screen);
            PageManager.Add("GoTo2Screen", OnGo2Screen);
            PageManager.Add("GoTo3Screen", OnGo3Screen);
            PageManager.Add("GoTo4Screen", OnGo4Screen);
        }

        public DelegateCommand _ToggleButtonCommand;
        protected void ToggleButton(object parameter)
        {
            CurrentPageViewModel = (CurrentPageViewModel == PageViewModels[0]) ? PageViewModels[1] : PageViewModels[0];
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
            CurrentPageViewModel = PageViewModels[2];
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


        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
