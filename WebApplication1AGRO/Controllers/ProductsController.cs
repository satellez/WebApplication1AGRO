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
            var products1 = await _productsService.GetAllProductsAsync();
            return Ok(products1);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Products>> GetProductsById(int id)
        {
            var products = await _productsService.GetProductsByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProducts([FromBody] Products products)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productsService.CreateProductsAsync(products);
            return CreatedAtAction(nameof(GetProductsById), new { id = products.Product_id }, products);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateProducts(int id, [FromBody] Products products)
        {
            if (id != products.Product_id)
                return BadRequest();

            var existingProducts = await _productsService.GetProductsByIdAsync(id);
            if (existingProducts == null)
                return NotFound();

            await _productsService.UpdateProductsAsync(products);
            return NoContent();

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteProducts(int id)
        {
            var products = await _productsService.GetProductsByIdAsync(id);
            if (products == null)
                return NotFound();

            await _productsService.SoftDeleteProductsAsync(id);
            return NoContent();
        }

    }
}
