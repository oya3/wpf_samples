
namespace WpfApp1.Models
{
    class UserModel : Common.BindableBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { set; get; }
        public string Address { get; set; }
        public string Tel { set; get; }
    }
}
