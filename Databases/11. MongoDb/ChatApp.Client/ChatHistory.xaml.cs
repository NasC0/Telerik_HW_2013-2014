using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChatApp.Model;
using MongoDB.Driver;

namespace ChatApp.Client
{
    /// <summary>
    /// Interaction logic for ChatHistory.xaml
    /// </summary>
    public partial class ChatHistory : Window
    {
        public ChatHistory(MongoDatabase dbContext)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            var messagesDocument = this.DbContext.GetCollection<Message>("Messages");
            var allMessages = messagesDocument.FindAll();
            this.MessageList.ItemsSource = allMessages;
        }

        public MongoDatabase DbContext { get; set; }
    }
}
