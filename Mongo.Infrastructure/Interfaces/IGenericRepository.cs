using Mongo.Entity.Entities;

namespace Mongo.Infrastructure.Interfaces
{
    public interface IGenericRepository<TDocument> where TDocument : BaseEntity
    {
        Task<List<TDocument>> GetAll();
        TDocument FindById(string id);
        Task<bool> InsertOne(TDocument document);
        Task<TDocument> ReplaceOne(TDocument document);
        Task<bool> DeleteById(string id);



    }
}
