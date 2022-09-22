using Mongo.Entity.Entities;
using Mongo.Infrastructure.Interfaces;

namespace Mongo.Infrastructure.Repositories
{

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(DBSettings.Interface.IMongoDatabase settings) : base(settings)
        {
        }


    }
}
