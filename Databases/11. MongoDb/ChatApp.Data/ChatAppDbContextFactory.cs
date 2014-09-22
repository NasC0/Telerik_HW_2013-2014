using MongoDB.Driver;

namespace ChatApp.Data
{
    public class ChatAppDbContextFactory
    {
        private const string DatabaseHost = "mongodb://chatUser:telerik@ds033380.mongolab.com:33380/chatdb";
        private const string DatabaseName = "chatdb";

        public static MongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient(DatabaseHost);
            var mongoServer = mongoClient.GetServer();
            var databaseContext = mongoServer.GetDatabase(DatabaseName);
            return databaseContext;
        }
    }
}
