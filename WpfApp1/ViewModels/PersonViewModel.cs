using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApp1.Models;


namespace WpfApp1.ViewModels
{
    class PersonViewModel //: INotifyPropertyChanged
    {
        // public event PropertyChangedEventHandler PropertyChanged;

        public PersonViewModel()
        {

        }

        public DelegateCommand _ButtonCommand;
        protected void Button(object parameter)
        {
            //  CurrentPage = (CurrentPage == Main) ? (object)Sub : (object)Main;
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
        /*
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
        */
        public object Person { get; set; } = PersonModel.Instance;

    }
}
