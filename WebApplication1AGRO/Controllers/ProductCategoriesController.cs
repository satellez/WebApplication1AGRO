using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesServices;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesService _offersService;

        public ProductCategoriesController(IProductCategoriesService offersService)
        {
            _offersService = offersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetAllProductCategories()
        {
            var offers1 = await _offersService.GetAllProductCategoriesAsync();
            return Ok(offers1);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductCategories>> GetProductCategoriesById(int id)
        {
            var offers = await _offersService.GetProductCategoriesByIdAsync(id);
            if (offers == null)
            {
                return NotFound();
            }
            return Ok(offers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductCategories([FromBody] ProductCategories offers)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _offersService.CreateProductCategoriesAsync(offers);
            return CreatedAtAction(nameof(GetProductCategoriesById), new { id = offers.Category_id }, offers);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateProductCategories(int id, [FromBody] ProductCategories offers)
        {
            if (id != offers.Category_id)
                return BadRequest();

            var existingProductCategories = await _offersService.GetProductCategoriesByIdAsync(id);
            if (existingProductCategories == null)
                return NotFound();

            await _offersService.UpdateProductCategoriesAsync(offers);
            return NoContent();

        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteProductCategories(int id)
        {
            var offers = await _offersService.GetProductCategoriesByIdAsync(id);
            if (offers == null)
                return NotFound();

            await _offersService.SoftDeleteProductCategoriesAsync(id);
            return NoContent();
        }

    }
}