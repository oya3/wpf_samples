using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand _PageOneCommand;

        public MainViewModel()
        {

        }
        protected void PageOne(object parameter)
        {
            //var navigationWindow = (NavigationWindow)Application.Current.MainWindow;
            //navigationWindow.Navigate(new SecondPage(), parameter);

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
            var h = this.PropertyChanged;
            if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
            
        }
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
            set { this.SetProperty(ref this.mail, value); }
        }

    }
}
