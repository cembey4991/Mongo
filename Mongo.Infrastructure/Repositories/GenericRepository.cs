using Mongo.Entity.Entities;
using Mongo.Infrastructure.DBSettings.Interface;
using Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;



namespace Mongo.Infrastructure.Repositories
{
    public class GenericRepository<TDocument> : IGenericRepository<TDocument> where TDocument : BaseEntity
    {
        //private  MongoClient _mongoClient = null;
        //private IMongoDatabase _database = null;
        //private IMongoCollection<Product> _product = null;

        private readonly IMongoCollection<TDocument> _collection;
        public GenericRepository(DBSettings.Interface.IMongoDatabase settings)
        {
            //_context=context;
            //_collection = _context.GetCollection<TDocument>(typeof(TDocument).Name);

            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(typeof(TDocument).Name);

            //var mongoClient = new MongoClient(options.Value.ConnectionString);
            //var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            //_collection = mongoDatabase.GetCollection<TDocument>(options.Value.ProductCollectionName    );
            //_mongoClient=new MongoClient("mongodb://localhost:27017");
            //_database = _mongoClient.GetDatabase("MongoDb");
            //_product = _database.GetCollection<Product>("Mongo");
        }


        public Task<List<TDocument>> GetAll()
        {
            return _collection.AsQueryable().ToListAsync();
        }

        public async Task<bool> DeleteById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, id);
            var deleteResult = await _collection.DeleteOneAsync(filter);
            return true;
        }

        public TDocument FindById(string id)
        {

            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public async Task<bool> InsertOne(TDocument document)
        {

            await _collection.InsertOneAsync(document);
            return true;
        }

        public Task<TDocument> ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, document.Id);
            var result = _collection.FindOneAndReplaceAsync(filter, document);
            return result;
        }

       
    }
}
