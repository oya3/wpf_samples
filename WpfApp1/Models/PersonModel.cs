using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    public sealed class PersonModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _Name = "oya";
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
        private string _Mail = "oya@test.com";
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
