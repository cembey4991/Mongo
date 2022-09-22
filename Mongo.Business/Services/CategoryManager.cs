using Mongo.Business.Interface;
using Mongo.Entity.Entities;
using Mongo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Business.Services
{
    public class CategoryManager :GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository repository):base(repository)
        {
            _categoryRepository = repository;
        }

      
    }
}
