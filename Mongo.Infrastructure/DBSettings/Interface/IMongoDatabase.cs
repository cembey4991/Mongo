namespace Mongo.Infrastructure.DBSettings.Interface
{
    public interface IMongoDatabase
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
