using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesService;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            var products = await _productsService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Products>> GetProductsById(int id)
        {
            var product = await _productsService.GetProductsByIdAsync(id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProducts([FromBody] Products product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productsService.CreateProductsAsync(product);
            return CreatedAtAction(nameof(GetProductsById), new { id = product.Product_id }, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProducts(int id, [FromBody] Products product)
        {
            if (id != product.Product_id)
                return BadRequest("Product ID mismatch.");

            var existingProduct = await _productsService.GetProductsByIdAsync(id);
            if (existingProduct == null)
                return NotFound($"Product with ID {id} not found.");

            await _productsService.UpdateProductsAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProducts(int id)
        {
            var product = await _productsService.GetProductsByIdAsync(id);
            if (product == null)
                return NotFound($"Product with ID {id} not found.");

            await _productsService.SoftDeleteProductsAsync(id);
            return NoContent();
        }
    }
}
