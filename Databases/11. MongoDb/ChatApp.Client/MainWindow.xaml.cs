using System.Windows;

namespace ChatApp.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = this.Username.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                
            }
            else
            {
                var chatWindow = new Chat(username);
                chatWindow.Show();
                this.Close();
            }
        }
    }
}
