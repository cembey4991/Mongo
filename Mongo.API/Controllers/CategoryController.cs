using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Business.Interface;
using Mongo.Entity.Entities;

namespace Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var addCategory = await _categoryService.InsertOne(category);
            return Ok(addCategory);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
           
            return Ok( await _categoryService.GetAll());
        }
        [HttpPut]
        public async Task<IActionResult> ReplaceCategory(Category category)
        {
            var update = await _categoryService.ReplaceOne(category);
            return Ok(update);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryFindById(string id)
        {
            var findCategory = _categoryService.FindById(id);
            return Ok(findCategory);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteById(id);
            return NoContent();
        }
      
       

        //[HttpGet]
        //public async Task<IActionResult> GetAllCategories()
        //{

        //   await _categoryService.InsertOne(new Entity.Entities.Category
        //    {
        //        Name = "Teknoloji"
        //    });

        //    var category = (await _categoryService.GetAll()).FirstOrDefault(I => I.Name == "Teknoloji");

        //    await _productService.InsertOne(new Entity.Entities.Product
        //    {
        //        CategoryId = category.Id,
        //        Name = "Samsung S10+ Akıllı Telefon",
        //        Price = 15000
        //    });



        //     return Ok( await _productService.GetAll());

        //}

    }
}
