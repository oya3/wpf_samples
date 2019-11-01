using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    class PersonModel : Common.BindableBase
    {
        private static readonly PersonModel instance = new PersonModel();
        private PersonModel() { }
        public static PersonModel Instance
        {
            get
            {
                return instance;
            }
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                if (value == _Name)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        private string _Mail;
        public string Mail
        {
            get => _Mail;
            set
            {
                if (value == _Mail)
                    return;
                _Mail = value;
                RaisePropertyChanged();
            }
        }

    }
}
