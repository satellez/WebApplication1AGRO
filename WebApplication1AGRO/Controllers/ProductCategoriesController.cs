using Microsoft.AspNetCore.Mvc;
using WebApplication1AGRO.Model;
using WebApplication1AGRO.Services.InterfacesService;

namespace WebApplication1AGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesService _productCategoriesService;

        public ProductCategoriesController(IProductCategoriesService productCategoriesService)
        {
            _productCategoriesService = productCategoriesService;
        }

        // Obtener todas las categorías de producto
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetAllProductCategories()
        {
            var productCategories = await _productCategoriesService.GetAllProductCategoriesAsync();
            return Ok(productCategories);
        }

        // Obtener una categoría de producto por ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCategories>> GetProductCategoriesById(int id)
        {
            var productCategory = await _productCategoriesService.GetProductCategoriesByIdAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return Ok(productCategory);
        }

        // Crear una nueva categoría de producto
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductCategories([FromBody] ProductCategories productCategories)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productCategoriesService.CreateProductCategoriesAsync(productCategories);
            return CreatedAtAction(nameof(GetProductCategoriesById), new { id = productCategories.Category_id }, productCategories);
        }

        // Actualizar una categoría de producto existente
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductCategories(int id, [FromBody] ProductCategories productCategories)
        {
            if (id != productCategories.Category_id)
                return BadRequest();

            var existingProductCategory = await _productCategoriesService.GetProductCategoriesByIdAsync(id);
            if (existingProductCategory == null)
                return NotFound();

            await _productCategoriesService.UpdateProductCategoriesAsync(productCategories);
            return NoContent();
        }

        // Eliminar lógicamente una categoría de producto
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProductCategories(int id)
        {
            var productCategory = await _productCategoriesService.GetProductCategoriesByIdAsync(id);
            if (productCategory == null)
                return NotFound();

            await _productCategoriesService.SoftDeleteProductCategoriesAsync(id);
            return NoContent();
        }
    }
}
