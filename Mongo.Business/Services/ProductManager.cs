using Mongo.Business.Interface;
using Mongo.Entity.Entities;
using Mongo.Infrastructure.Interfaces;

namespace Mongo.Business.Services
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }

      


        public Task<List<Product>> GetProductsContainsName(string productName)
        {
            return _productRepository.GetProductsContainsName(productName);
        }
    }
}
