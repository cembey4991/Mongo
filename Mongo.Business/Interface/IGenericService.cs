using Mongo.Entity.Entities;

namespace Mongo.Business.Interface
{
    public interface IGenericService<TDocument> where TDocument : BaseEntity
    {
        Task<bool> InsertOne(TDocument document);
        Task<List<TDocument>> GetAll();
        TDocument FindById(string id);
        Task<TDocument> ReplaceOne(TDocument document);
        Task<bool> DeleteById(string id);

    }
}
