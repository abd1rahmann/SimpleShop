using BusinessLogicLayer.Services.Products;
using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace SimpleShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
        {
            var createdProduct = await _productService.CreateProductAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = createdProduct?.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var success = await _productService.UpdateProductAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteProductAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}
