using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;


namespace WpfMaterials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<User> users = new();

        public MainWindow()
        {
            InitializeComponent();

            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() { Name = "Jane Doe" });

            lbUsers.ItemsSource = users;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "New user" });
        }

        private void BtnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                ((User)lbUsers.SelectedItem).Name = "Random Name";
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                users.Remove((User)lbUsers.SelectedItem);
        }
    }
    public class User : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
