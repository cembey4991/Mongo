using Mongo.Business.Interface;
using Mongo.Entity.Entities;
using Mongo.Infrastructure.Interfaces;

namespace Mongo.Business.Services
{
    public class GenericManager<TDocument> : IGenericService<TDocument> where TDocument : BaseEntity
    {
        private readonly IGenericRepository<TDocument> _repository;

        public GenericManager(IGenericRepository<TDocument> repository)
        {
            _repository = repository;
        }

        public async Task<List<TDocument>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<bool> DeleteById(string id)
        {
            return _repository.DeleteById(id);
        }

        public TDocument FindById(string id)
        {
            return _repository.FindById(id);
        }

        public async Task<bool> InsertOne(TDocument document)
        {
            var result = await _repository.InsertOne(document);
            return result;
        }

        public async Task<TDocument> ReplaceOne(TDocument document)
        {
            return await _repository.ReplaceOne(document);
        }
    }
}
