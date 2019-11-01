using System.Windows.Controls;


namespace WpfApp1.Views
{
    /// <summary>
    /// UsersView.xaml の相互作用ロジック
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users.ScrollIntoView(Users.SelectedItem);
        }
    }
}
