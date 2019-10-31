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

        public MainWindowViewModel()
        {
            // Add available pages and set page
            PageViewModels.Add(new PersonViewModel());
            PageViewModels.Add(new AnimalViewModel());

            CurrentPageViewModel = PageViewModels[0];

            PageManager.Add("GoTo1Screen", OnGo1Screen);
            PageManager.Add("GoTo2Screen", OnGo2Screen);
        }

        public DelegateCommand _PageOneCommand;
        protected void PageOne(object parameter)
        {
            CurrentPageViewModel = (CurrentPageViewModel == PageViewModels[0]) ? PageViewModels[1] : PageViewModels[0];
        }

        public DelegateCommand PageOneCommand
        {
            get
            {
                if (this._PageOneCommand == null)
                {
                    this._PageOneCommand = new DelegateCommand(PageOne);
                }

                return this._PageOneCommand;
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
