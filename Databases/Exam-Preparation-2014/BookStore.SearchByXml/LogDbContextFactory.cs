using MongoDB.Driver;
namespace BookStore.SearchByXml
{
    public class LogDbContextFactory
    {
        private const string DatabaseHost = "mongodb://localhost";
        private const string DatabaseName = "logsdb";

        public static MongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient(DatabaseHost);
            var mongoServer = mongoClient.GetServer();
            var databaseContext = mongoServer.GetDatabase(DatabaseName);
            return databaseContext;
        }
    }
}
