using Application.ServicesIntefaces;
using Domain.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _productService.GetAll();

            //var result = _productService.GetAllDapper();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _productService.GetById(id);

            //var result = _productService.GetByIdDapper(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _productService.Add(product);

            //_productService.AddDapper(product);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Product product)
        {
            _productService.Update(product);

            //_productService.UpdateDapper(product);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _productService.Remove(id);

            //_productService.RemoveDapper(id);

            return Ok();
        }
    }
}