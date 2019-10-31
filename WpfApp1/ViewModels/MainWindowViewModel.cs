using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            // 画面遷移に使うためだけのviewmodelインスタンス
            Main = new PersonViewModel();
            Sub = new AnimalViewModel();
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

        private PersonViewModel _Main;
        public PersonViewModel Main
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
        private AnimalViewModel _Sub;
        public AnimalViewModel Sub
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

        public DelegateCommand _PageOneCommand;
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


        public DelegateCommand _ButtonCommand;
        protected void Button(object parameter)
        {
            PageOne(parameter);
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
