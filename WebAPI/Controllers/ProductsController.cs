using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var dataResult = _productService.GetList();
            if (dataResult.Success)
            {
                return Ok(dataResult.Result);
            }

            return BadRequest(dataResult.Message);
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var dataResult = _productService.GetListByCategory(categoryId);
            if (dataResult.Success)
            {
                return Ok(dataResult.Result);
            }

            return BadRequest(dataResult.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var dataResult = _productService.GetById(productId);
            if (dataResult.Success)
            {
                return Ok(dataResult.Result);
            }

            return BadRequest(dataResult.Message);
        }

        [HttpPost("add")]
        public IActionResult addProduct(Product product)
        {
            var dataResult = _productService.Add(product);
            if (dataResult.Success)
            {
                return Ok(dataResult.Message);
            }

            return BadRequest(dataResult.Message);
        }

        [HttpPut("update")]
        public IActionResult updateProduct(Product product)
        {
            var dataResult = _productService.Update(product);
            if (dataResult.Success)
            {
                return Ok(dataResult.Message);
            }

            return BadRequest(dataResult.Message);
        }

        [HttpPost("delete")]
        public IActionResult deleteProduct(Product product)
        {
            var dataResult = _productService.Delete(product);
            if (dataResult.Success)
            {
                return Ok(dataResult.Message);
            }

            return BadRequest(dataResult.Message);
        }
    }
}
