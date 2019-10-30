using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand _PageOneCommand;

        public MainWindowViewModel()
        {
            // 画面遷移に使うためだけのviewmodelインスタンス
            Main = new MainViewModel();
            Sub = new SubViewModel();
            CurrentPage = Main;
        }

        private object _CurrentPage;
        public object CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                if (_CurrentPage != value)
                {
                    this.SetProperty(ref this._CurrentPage, value);
                }
            }
        }

        private MainViewModel _Main;
        public MainViewModel Main
        {
            get { return _Main; }
            set
            {
                if (_Main != value)
                {
                    this.SetProperty(ref this._Main, value);
                }
            }
        }
        private SubViewModel _Sub;
        public SubViewModel Sub
        {
            get { return _Sub; }
            set
            {
                if (_Sub != value)
                {
                    this.SetProperty(ref this._Sub, value);
                }
            }
        }

        protected void PageOne(object parameter)
        {
            CurrentPage = (CurrentPage == Main) ? (object)Sub : (object)Main;
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
            //var h = this.PropertyChanged;
            //if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
        }
        /*
        private string name;
        private string mail;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

        public string Mail
        {
            get { return this.mail; }
            set { }
        }
        */
    }
}
