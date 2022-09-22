using Mongo.Entity.Entities;
using Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ServiceStack;

namespace Mongo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;


        public ProductRepository(DBSettings.Interface.IMongoDatabase settings) : base(settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _productCollection = database.GetCollection<Product>(typeof(Product).Name);

        }




        public async Task<List<Product>> GetProductsContainsName(string productName)
        {
            var query = _productCollection.AsQueryable().Where(c => c.Name.ToLower().Contains(productName.ToLower()));
            return query.ToList();
        }
    }
}
