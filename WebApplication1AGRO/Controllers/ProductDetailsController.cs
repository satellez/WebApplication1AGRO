using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesService;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _productDetailsService;

        public ProductDetailsController(IProductDetailsService productDetailsService)
        {
            _productDetailsService = productDetailsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductDetails>>> GetAllProductDetails()
        {
            var productDetails1 = await _productDetailsService.GetAllProductDetailsAsync();
            return Ok(productDetails1);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDetails>> GetProductDetailsById(int id)
        {
            var productDetails = await _productDetailsService.GetProductDetailsByIdAsync(id);
            if (productDetails == null)
            {
                return NotFound($"ProductDetails with ID {id} not found.");
            }
            return Ok(productDetails);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductDetails([FromBody] ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productDetailsService.CreateProductDetailsAsync(productDetails);
            return CreatedAtAction(nameof(GetProductDetailsById), new { id = productDetails.ProdDeta_id }, productDetails);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductDetails(int id, [FromBody] ProductDetails productDetails)
        {
            if (id != productDetails.ProdDeta_id)
                return BadRequest("ProductDetails ID mismatch.");

            var existingProductDetails = await _productDetailsService.GetProductDetailsByIdAsync(id);
            if (existingProductDetails == null)
                return NotFound($"ProductDetails with ID {id} not found.");

            await _productDetailsService.UpdateProductDetailsAsync(productDetails);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProductDetails(int id)
        {
            var productDetails = await _productDetailsService.GetProductDetailsByIdAsync(id);
            if (productDetails == null)
                return NotFound($"ProductDetails with ID {id} not found.");

            await _productDetailsService.SoftDeleteProductDetailsAsync(id);
            return NoContent();
        }
    }
}
