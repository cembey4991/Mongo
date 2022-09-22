using Microsoft.AspNetCore.Mvc;
using Mongo.Business.Interface;
using Mongo.Entity.Entities;

namespace Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            _productService = productService;
       
        }


        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _productService.InsertOne(product);
            return Ok(true);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsContainsName(string productName)
        {
            var result = await _productService.GetProductsContainsName(productName);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ReplaceProduct(Product product)
        {
            var result = await _productService.ReplaceOne(product);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            var product = _productService.FindById(id);
            return Ok(product);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            await _productService.DeleteById(id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAll();
           
            return Ok(products);
        }
       


    }
}
