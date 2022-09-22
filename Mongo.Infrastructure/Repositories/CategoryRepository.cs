using Mongo.Entity.Entities;
using Mongo.Infrastructure.DBSettings.Interface;
using Mongo.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Mongo.Infrastructure.Repositories
{

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(DBSettings.Interface.IMongoDatabase settings) : base(settings)
        {
        }

       
    }
}
