using Mongo.Entity.Entities;

namespace Mongo.Business.Interface
{
    public interface IProductService : IGenericService<Product>
    {
        Task<List<Product>> GetProductsContainsName(string productName);


    }
}
