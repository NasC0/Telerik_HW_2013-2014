using System;
using System.Windows;
using System.Windows.Threading;
using ChatApp.Data;
using ChatApp.Model;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ChatApp.Client
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private IMongoQuery messagesQuery;

        private DispatcherTimer timer;

        public Chat(string username)
        {
            InitializeComponent();
            this.Username = username;
            this.DbContext = ChatAppDbContextFactory.GetDatabase();
            this.LoginTime = DateTime.Now;
            this.messagesQuery = Query<Message>.Where(msg => msg.MsgDate >= this.LoginTime);
            this.PopulateChatGrid();
            this.StartTimer();
        }

        private string Username { get; set; }

        private MongoDatabase DbContext { get; set; }

        private DateTime LoginTime { get; set; }

        private void PopulateChatGrid()
        {
            var messagesDocument = this.DbContext.GetCollection<Message>("Messages");
            var messageCollection = messagesDocument.Find(this.messagesQuery);

            this.MessageList.ItemsSource = messageCollection;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.MessageText.Text))
            {
                MessageBox.Show("Invalid message.");
                return;
            }

            var curentMessage = new Message()
            {
                MsgDate = DateTime.Now,
                MsgText = this.MessageText.Text,
                User = new User() { Username = this.Username }
            };

            try
            {
                this.DbContext.GetCollection<Message>("Messages").Insert(curentMessage);   
                MessageBox.Show("Added succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs a)
        {
            this.PopulateChatGrid();
        }

        private void ShowHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var messageHistory = new ChatHistory(this.DbContext);
            messageHistory.ShowDialog();
            this.Show();
        }
    }
}
