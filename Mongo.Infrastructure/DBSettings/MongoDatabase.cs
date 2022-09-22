using Mongo.Infrastructure.DBSettings.Interface;

namespace Mongo.Infrastructure.DBSettings
{
    public class MongoDatabase : IMongoDatabase
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
