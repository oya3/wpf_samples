
namespace WpfApp1.Models
{
    class UserModel : Common.BindableBase
    {
        private int _ID;
        public int ID {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
                RaisePropertyChanged();
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                RaisePropertyChanged();
            }
        }

        private string _Mail;
        public string Mail
        {
            get
            {
                return this._Mail;
            }
            set
            {
                this._Mail = value;
                RaisePropertyChanged();
            }
        }
        private string _Address;
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
                RaisePropertyChanged();
            }
        }
        private string _Tel;
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                this._Tel = value;
                RaisePropertyChanged();
            }
        }
    }
}
