using Mongo.Entity.Entities;

namespace Mongo.Infrastructure.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsContainsName(string ProductName);


    }
}
